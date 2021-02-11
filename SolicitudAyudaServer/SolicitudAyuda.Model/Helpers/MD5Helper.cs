using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SolicitudAyuda.Model.Helpers
{
    public class MD5Helper
    {
        public static string MD5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                return Encoding.ASCII.GetString(result);
            }
        }
    }
}
