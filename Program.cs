using System;
using System.Collections.Generic;

namespace Independency
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dependencies:");

            var dependents = new List<DependentItemConfig>() { new DependentItemConfig { Parnet = 1, Child = 2 },
                                                               new DependentItemConfig { Parnet = 1, Child = 3 },
                                                               new DependentItemConfig { Parnet = 2, Child = 4 },
                                                               new DependentItemConfig { Parnet = 3, Child = 4 },
                                                               new DependentItemConfig { Parnet = 3, Child = 5 }};

            var independentManager = new IndependentManager();

            independentManager.LoadCOnfiguration(dependents);
            
            independentManager.GetIndependenList(); // 1

            independentManager.Print();

            independentManager.SetSuccess(1); 

            independentManager.Print();

            independentManager.GetIndependenList(); // 2,3

            independentManager.Print();

            independentManager.SetSuccess(3); 

            independentManager.Print();

            independentManager.GetIndependenList();  // 5

            independentManager.GetIndependenList(); //  Empty list - 5 Already running

            independentManager.Print();

            independentManager.SetFail(2); // 2 and 4 becomes Fail.

            independentManager.Print();

            Console.ReadLine();

        }
    }
}
