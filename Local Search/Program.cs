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
            String FinalStateOfEightQueenUsingHillClimbing = HillClimbing.SolveEightPuzzle();
            Console.WriteLine(FinalStateOfEightQueenUsingHillClimbing);
            Console.WriteLine("Final State Heuristic = " + Util.Heuristic(FinalStateOfEightQueenUsingHillClimbing));
        }
    }
}
