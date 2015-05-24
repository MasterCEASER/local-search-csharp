using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Local_Search
{
    class HillClimbing
    {
        static String getRandomChildState(String parrent)
        {
            Random RandomObj = new Random(DateTime.Now.Millisecond);
            int indexToBeChanged = RandomObj.Next(0,7);
            Int32[] ParrentInt = parrent.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            int NumberReplaced = Util.RandomNumberExceptNumber(0, 7, ParrentInt[indexToBeChanged]);
            ParrentInt[indexToBeChanged] = NumberReplaced;
            return String.Join(" ", ParrentInt);
        }
        public static String SolveEightPuzzle()
        {
            int ComputationalBudget = 50;
            String InitialState = Util.InitiateRandomEightQueen();
            Console.WriteLine("Initial State = " + InitialState);
            int InitialStateHeuristic = Util.Heuristic(InitialState);
            Console.WriteLine("Initial State Heuristic = " + InitialStateHeuristic);
            int count = 0;
            String RandomChild;
            while (true)
            {
                RandomChild = getRandomChildState(InitialState);
                while (Util.Heuristic(InitialState) < Util.Heuristic(RandomChild) && count < ComputationalBudget)
                {
                    RandomChild = getRandomChildState(InitialState);
                    count++;
                }
                if (count >= ComputationalBudget)
                    break;
                count = 0;
                InitialState = RandomChild;
            }
            if (Util.Heuristic(InitialState) < Util.Heuristic(RandomChild))
                return InitialState;
            else
                return RandomChild;
        }
    }
}