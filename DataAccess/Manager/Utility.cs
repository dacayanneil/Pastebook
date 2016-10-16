using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Manager
{
    class Utility
    {
        public string GetString(byte[] input)
        {
            string output = "";
            output = ASCIIEncoding.ASCII.GetString(input);
            return output;
        }

        public byte[] GetBytes(string input)
        {
            byte[] output;
            output = ASCIIEncoding.ASCII.GetBytes(input);
            return output;
        }
    }
}
