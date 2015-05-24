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
            String FinalStateOfEightQueenUsingHillClimbing = HillClimbing.SolveEightPuzzle(10);
            Console.WriteLine("Hill Climbing = " + FinalStateOfEightQueenUsingHillClimbing);
            Console.WriteLine("Final State Heuristic = " + Util.Heuristic(FinalStateOfEightQueenUsingHillClimbing));

            String FinalStateOfEightQueenUsingkBeam = KBeamSearch.SolveEightPuzzle(3,5);
            Console.WriteLine("K beam = " + FinalStateOfEightQueenUsingkBeam);
            Console.WriteLine("Final State heuristic using K beam = "+Util.Heuristic(FinalStateOfEightQueenUsingkBeam));

        }
    }
}
