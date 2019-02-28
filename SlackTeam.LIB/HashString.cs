using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlackTeam.LIB;

namespace SlackTeam.LIB
{
    public class HashString
    {
        private static String DefaultKey = "Bravo@Hill2018xyzAbc";

        public static String Encrypt(String Password)
        {
            return StringCipher.Encrypt(Password, DefaultKey);
        }

        public static String Decrypt(String EncryptedString)
        {
            return StringCipher.Decrypt(EncryptedString, DefaultKey);
        }

    }
}
