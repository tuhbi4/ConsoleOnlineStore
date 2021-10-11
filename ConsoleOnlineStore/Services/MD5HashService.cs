using System;
using System.Security.Cryptography;
using System.Text;
using ConsoleOnlineStore.Interfaces;

namespace ConsoleOnlineStore.Services
{
    public class MD5HashService : IHashService
    {
        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }
    }
}