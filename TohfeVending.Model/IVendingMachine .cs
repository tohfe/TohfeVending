using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TohfeVending.Model
{
    public interface IVendingMachine
    {
    }

    public interface IAddable
    {
        void Add(IngredientContainer container);
        string Name { get; }
    }
}
