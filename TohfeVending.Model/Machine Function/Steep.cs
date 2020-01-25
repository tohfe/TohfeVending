using System.Threading.Tasks;

namespace TohfeVending.Model
{
    public class Steep : AbstractIngredientBasedMachineFunction
    {
        public Steep(Ingredient ingredient) : base("Steep", ingredient)
        {
        }

        public override string GetLable()
        {
            return $"{base.GetLable()} in hot water";
        }

        internal async override Task Do()
        {
            STEEP();

            await base.Do();
        }

        protected void STEEP()
        {
            //TODO:
        }
    }
}
