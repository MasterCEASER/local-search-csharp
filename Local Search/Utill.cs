using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Local_Search
{
    class Utill
    {
        public static String InitiateRandomEightQueen()
        {
            Random RandomObj = new Random();
            int[] stateInt = new int[8];
            for (int i = 0; i < 8; i++)
            {
                stateInt[i] = RandomObj.Next(1,8);
            }
            return String.Join(" ",stateInt);
        }
    }
}
