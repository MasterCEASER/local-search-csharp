using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Local_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            String InitialState = Utill.InitiateRandomEightQueen();
            Console.WriteLine(InitialState);
            int InitialStateHeuristic = Utill.Heuristic(InitialState);
            Console.WriteLine(InitialStateHeuristic + "");
        }
    }
}
