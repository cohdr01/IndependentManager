using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Independency
{
    class IndependentManager : IIndependentManager
    {
        public Dictionary<int, DependentItem> ItemsList { get; set; } = new Dictionary<int, DependentItem>();
        public void LoadCOnfiguration(List<DependentItemConfig> dependents)
        {
            foreach (var d in dependents)
            {

                if (!ItemsList.TryGetValue(d.Parnet, out DependentItem parent))
                {
                    parent = new DependentItem(d.Parnet);
                    ItemsList.Add(d.Parnet, parent);
                }


                /*DependentItem p;
                if (DependentItemsList.ContainsKey(d.Parnet))
                {
                    p = DependentItemsList[d.Parnet];
                }
                else 
                { 
                    p = new DependentItem(d.Parnet);
                    DependentItemsList.Add(d.Parnet, p);
                };*/

                
                if (!ItemsList.TryGetValue(d.Child, out DependentItem child))
                {
                    child = new DependentItem(d.Child);
                    ItemsList.Add(d.Child, child);
                }

                parent.AddChild(child);

                Console.WriteLine($"Config line suceess: {d.Parnet} - {d.Child}");
            }

        }

        public List<int> GetIndependenList()
        {
            var Independets = ItemsList.Where(o => o.Value.IsIndependent()).Select(d => d.Key).ToList();
            Console.WriteLine($"--> List of Independent items(s): {string.Join(", ",Independets)}");
            return Independets;
        }

        public void SetFail(int Id)
        {
            Console.WriteLine($"--> SetFail({Id})");
            ItemsList[Id]?.SetFail();
        }

        public void SetSuccess(int Id)
        {
            Console.WriteLine($"--> SetSuccess({Id})");
            ItemsList[Id]?.SetSuccess();
        }

        internal void Print()
        {
            var list = ItemsList.Select(o => new string($"{o.Key} : {o.Value.Status}"));
            Console.WriteLine($"\n--> List of all Items:\n\t{string.Join("\n\t", list)}\n");
        }
    }
}
