using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementing_Graph_Using_Adjacency_Matrix.Utility_Class
{
    public class clsUtil
    {

        public static void PrintSeparator(char sep , int length)
        {
            if (length <= 0)
                length = 25;

            if (sep == ' ')
                sep = '-';

            Console.WriteLine(new string(sep, length));
        }


    }
}
