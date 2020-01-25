using System.Threading.Tasks;

namespace TohfeVending.Model
{
    public class ChangeContainer : AbstractMachineFunction
    {
        public ChangeContainer(IngredientContainer container) : base("ChangeContainer")
        {
            Container = container;
            Container.Set();
        }

        public IngredientContainer Container { get; }

        internal async override Task Do()
        {
            await Change();

            await base.Do();
        }

        async Task Change() => Container.Set();

        public override string GetLable() => null;
    }
}
