using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Local_Search
{
    class KBeamSearch
    {
        static String getRandomChildState(String parrent)
        {
            Random RandomObj = new Random(DateTime.Now.Millisecond);
            int indexToBeChanged = RandomObj.Next(0, 7);
            Int32[] ParrentInt = parrent.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            int NumberReplaced = Utill.RandomNumberExceptNumber(0, 7, ParrentInt[indexToBeChanged]);
            ParrentInt[indexToBeChanged] = NumberReplaced;
            return String.Join(" ", ParrentInt);
        }
        public static String SolveEightPuzzle()
        {
            int ComputationalBudget = 50;
            Random RandomObj = new Random(DateTime.Now.Millisecond);
            int k = RandomObj.Next(1,10);
            
            String[] InitialStates = new String[k];
            int[] InitialHeuristics = new int[k];
            String[] RandomChildsOfAllStates = new String[k*k];

            for (int i = 0; i < k; i++)
            {
                InitialStates[i] = Utill.InitiateRandomEightQueen();
            }
            for (int i = 0; i < k; i++)
            {
                Console.WriteLine("Initial State = " + InitialStates[i]);
                int InitialStateHeuristic = Utill.Heuristic(InitialStates[i]);
                Console.WriteLine("Initial State Heuristic = " + InitialStateHeuristic);
                int count = 0;
                String RandomChild;
                for (int j = 0; j < k; j++ )
                {
                    for (int L = 0; L < k; L++)
                    {
                        RandomChild = getRandomChildState(InitialStates[j]);
                        while (Utill.Heuristic(InitialStates[j]) < Utill.Heuristic(RandomChild) && count < ComputationalBudget)
                        {
                            RandomChild = getRandomChildState(InitialStates[j]);
                            count++;
                        }
                        if (count >= ComputationalBudget)
                        {
                            RandomChildsOfAllStates[(j * k) + L] = RandomChild;
                            break;
                        }
                        RandomChildsOfAllStates[(j * k) + L] = RandomChild;
                        count = 0;
                    }
                }
            }
            return "";
            //if (Utill.Heuristic(InitialState) < Utill.Heuristic(RandomChild))
            //    return InitialState;
            //else
            //    return RandomChild;
        }
    }
}
