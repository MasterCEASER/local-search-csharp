using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Local_Search
{
    class HillClimbing
    {
        public static String SolveEightPuzzle(int ComputationalBudget)
        {
            String InitialState = Util.InitiateRandomEightQueen();
            //Console.WriteLine("Initial State = " + InitialState);
            int InitialStateHeuristic = Util.Heuristic(InitialState);
            //Console.WriteLine("Initial State Heuristic = " + InitialStateHeuristic);
            int count = 0;
            String RandomChild = "";
            while (count <= ComputationalBudget)
            {
                RandomChild = Util.GetRandomChildState(InitialState);
                while (Util.Heuristic(InitialState) < Util.Heuristic(RandomChild) && count <= ComputationalBudget)
                {
                    RandomChild = Util.GetRandomChildState(InitialState);
                    count++;
                }
                if (Util.Heuristic(InitialState) < Util.Heuristic(RandomChild))
                    InitialState = RandomChild;
            }
            if (Util.Heuristic(InitialState) < Util.Heuristic(RandomChild))
                return InitialState;
            else
                return RandomChild;
        }
    }
}