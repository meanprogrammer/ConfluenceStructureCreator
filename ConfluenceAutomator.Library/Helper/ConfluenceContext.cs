using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{
    public static class ConfluenceContext
    {
        private static string _username;
        private static string _password;
        public static void SaveCredentials(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public static string GetFormattedCredential()
        {
            return string.Format("{0}:{1}", _username, _password);
        }

        public static string GetUsername()
        {
            return _username;
        }

        public static string GetPassword()
        {
            return _password;
        }
    }
}
