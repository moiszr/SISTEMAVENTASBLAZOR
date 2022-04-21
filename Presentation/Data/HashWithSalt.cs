﻿using System.Security.Cryptography;

namespace Presentation.Data
{
    public class HashWithSalt
    {
        public static string Hash(string plainText)
        {
            byte[] salt;
            byte[] buffer;
            if (plainText == null)
            {
                throw new ArgumentNullException(nameof(plainText));
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(plainText, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        public static bool Verify(string plainText, string hash)
        {
            byte[] buffer4;
            if (plainText == null)
            {
                throw new ArgumentNullException(nameof(plainText));
            }
            if (hash == null)
            {
                throw new ArgumentNullException(nameof(hash));
            }
            byte[] src = Convert.FromBase64String(hash);
            if (src.Length != 0x31 || src[0] != 0)
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(plainText, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }

        private static bool ByteArraysEqual(byte[] b1, byte[] b2)
        {
            if (b1 == b2)
            {
                return true;
            }
            if (b1 == null || b2 == null)
            {
                return false;
            }
            if (b1.Length != b2.Length)
            {
                return false;
            }
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
