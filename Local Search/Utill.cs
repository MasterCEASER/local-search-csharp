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
                stateInt[i] = RandomObj.Next(0,7);
            }
            return String.Join(" ",stateInt);
        }
        public static int Heuristic(String State)
        {
            Int32[] StateInt = State.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            int ColoumnCollisions = 0; //This will remain zero becasue we place a single queen in a column
            //Calculate Row collisions for all Queens
            int count = 1; // This is used in Diagonal Checking
            int RowCollisions = 0;
            int DiagonalColliions = 0;
            for (int i = 0; i < 8; i++)
            {
                count = 1;
                for (int j = i + 1; j < 8; j++)
                {
                    if (StateInt[i] == StateInt[j])
                    {
                        //Console.WriteLine("Row Collision: i =  " + i + " j = " + j);
                        RowCollisions++;
                    }
                    if (StateInt[i] == (StateInt[j] + count))
                    {
                        //Console.WriteLine("Diagonal Collision: i =  " + i + " j = " + j);
                        DiagonalColliions++;
                    }
                    if (StateInt[i] == (StateInt[j] - count))
                    {
                        //Console.WriteLine("Diagonal Collision: i =  " + i + " j = " + j);
                        DiagonalColliions++;
                    }
                    count++;
                }
            }
            return (RowCollisions + ColoumnCollisions + DiagonalColliions);
        }
        public static int RandomNumberExceptNumber(int start, int end, int num)
        {
            Random RandomObj = new Random(DateTime.Now.Millisecond);
            int result = RandomObj.Next(start,end);
            while (result == num)
            {
                result = RandomObj.Next(start, end);
            }
            return result;
        }
    }
}
