using System.Threading.Tasks;

namespace TohfeVending.Model
{
    public class Boil : AbstractIngredientBasedMachineFunction
    {
        public Boil(Ingredient ingredient) : base("Boil", ingredient)
        {
        }

        internal async override Task Do()
        {
            BOIL();

            await base.Do();
        }

        protected void BOIL()
        {
            //TODO:
        }
    }
}
