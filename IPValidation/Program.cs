using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IPValidation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsValidIp("137.255.156.100"));
            Console.ReadKey();
        }

        public static bool IsValidIp(string ipAddres) =>
            new Regex("^((2[0-5][0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[1-9]|0)\\.){3}(2[0-5][0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[1-9]|0)$")
            .IsMatch(ipAddres);


        public static bool IsValidIp1(string ipAddress)
        {
            var octets = ipAddress.Split('.');

            if (octets.Count() != 4) return false;

            foreach (var octet in octets)
            {
                if (!int.TryParse(octet, out int numericOctet))
                    return false;

                if (numericOctet < 0 || numericOctet > 255)
                    return false;

                if (!numericOctet.ToString().Equals(octet))
                    return false;
            }

            return true;
        }

        public static bool IsValidIp2(string ipAddress)
        {
            string[] octets = ipAddress.Split('.');

            if (octets.Length != 4)
                return false;

            foreach (string octet in octets)
            {
                int checkNum;
                bool isNumber = Int32.TryParse(octet, out checkNum) || false;

                if (!isNumber) return false;
                if (octet.Length > 1 && octet[0] == '0') return false;
                if (octet.Trim().Length != octet.Length) return false;
                if (checkNum < 0 || checkNum > 255) return false;
            }

            return true;
        }
    }
}
