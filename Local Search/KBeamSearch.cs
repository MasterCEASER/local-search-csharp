using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Local_Search
{
    class KBeamSearch
    {
        static String GetRandomChildState(String parrent)
        {
            Random RandomObj = new Random(DateTime.Now.Millisecond);
            int indexToBeChanged = RandomObj.Next(0, 7);
            Int32[] ParrentInt = parrent.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            int NumberReplaced = Util.RandomNumberExceptNumber(0, 7, ParrentInt[indexToBeChanged]);
            ParrentInt[indexToBeChanged] = NumberReplaced;
            return String.Join(" ", ParrentInt);
        }
        public static String SolveEightPuzzle(int K, int ComputationalBudget)
        {   
            int BudgetConsumed = 0;
            String[] ParentStates = new String[K];
            String[] RandomChildsOfAllStates = new String[K*K];
            
            for (int i = 0; i < K; ++i)
                ParentStates[i] = Util.InitiateRandomEightQueen();

            while (BudgetConsumed < ComputationalBudget)
            {
                
                for (int i = 0; i < K; ++i)
                {
                    for (int j = 0; j < K; ++j)
                    {
                        RandomChildsOfAllStates[i * K + j] = GetRandomChildState(ParentStates[j]);
                    }
                }
                Array.Sort(RandomChildsOfAllStates, new EightQuineComparer());
                ParentStates = RandomChildsOfAllStates.Take(K).ToArray();
                ++BudgetConsumed;
            }
            return null;
        }
    }
}
