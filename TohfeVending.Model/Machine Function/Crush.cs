using System.Threading.Tasks;

namespace TohfeVending.Model
{
    public class Crush : AbstractIngredientBasedMachineFunction
    {
        public Crush(AddableIngredient ingredient) : base("Crush", ingredient)
        {
        }

        internal async override Task Do()
        {
            CRUSH();

            await base.Do();
        }

        protected void CRUSH()
        {
            //TODO:
        }
    }
}
