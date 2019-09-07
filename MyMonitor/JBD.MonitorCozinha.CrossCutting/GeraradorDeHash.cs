using System;
using System.Security.Cryptography;
using System.Text;

namespace JBD.MonitorCozinha.CrossCutting
{
    public static class GeraradorDeHash
    {
        public static string GerarHash256(string password)
        {
            SHA256Managed hashstring = new SHA256Managed();
            byte[] bytes = Encoding.ASCII.GetBytes(Convert.ToString(password));
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = "m";
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}
