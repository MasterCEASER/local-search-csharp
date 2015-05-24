using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Local_Search
{
    class KBeamSearch
    {
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
                        RandomChildsOfAllStates[i * K + j] = Util.GetRandomChildState(ParentStates[j]);
                    }
                }
                Array.Sort(RandomChildsOfAllStates, new EightQuineComparer());
                Array.Sort(ParentStates, new EightQuineComparer());
                String FittestStateOfAllChilds = RandomChildsOfAllStates[0];
                //Final State Reached
                if(Util.Heuristic(FittestStateOfAllChilds) == 0)
                    return FittestStateOfAllChilds;
                //No child state is better than best parrent so, best parrent is our answer
                if (Util.Heuristic(FittestStateOfAllChilds) > Util.Heuristic(ParentStates[0]))
                    return ParentStates[0];
                ParentStates = RandomChildsOfAllStates.Take(K).ToArray();
                ++BudgetConsumed;
            }
            //When budget consume is over than best from the parrent states are our answer
            return ParentStates[0];
        }
    }
}
