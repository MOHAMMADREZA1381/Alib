﻿using System.Security.Cryptography;
using System.Text;

namespace Appliocation.PasswordHelper;

public class HashPassword
{
    public static string HasPassword(string Pass)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] originalBytes = Encoding.UTF8.GetBytes(Pass);
            byte[] encodedBytes = sha256.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes).Replace("-", "").ToLower();
        }
    }
}