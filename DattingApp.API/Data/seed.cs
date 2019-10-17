using System;
using System.Collections.Generic;
using System.Linq;
using DattingApp.API.Models;
using Newtonsoft.Json;

namespace DattingApp.API.Data
{
    public class seed
    {
        public static void SeedUser(DataContext context){
if(!context.Users.Any())
{
    var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
    var users = JsonConvert.DeserializeObject<List<User>>(userData);
    foreach (var user in users)
    {
        byte[] passwordHash, passwordSalt;

        CreatePasswordHash("password",out passwordHash, out passwordSalt);
        user.PasswordHash= passwordHash;
        user.PasswordSalt = passwordSalt;
        user.Username = user.Username.ToLower();
        context.Add(user);

    }

    context.SaveChanges();
}
        }
    
static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
           using( var hmac = new System.Security.Cryptography.HMACSHA512())     
{
    passwordSalt = hmac.Key;
    passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
}

        }
    }

}