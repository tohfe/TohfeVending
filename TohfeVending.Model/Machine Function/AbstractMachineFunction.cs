using System.Collections.Generic;
using System.Threading.Tasks;

namespace TohfeVending.Model
{
    public abstract class AbstractMachineFunction
    {
        public string Name { get; protected set; }

        public List<string> Functions { get; private set; }

        public AbstractMachineFunction(string name)
        {
            Name = name;
            Functions = new List<string>();
            Functions.Add(Name);
        }
        internal async virtual Task Do()
        {
            System.Threading.Thread.Sleep(2000);
        }

        public abstract string GetLable();
    }
}
