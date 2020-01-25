using System.Threading.Tasks;

namespace TohfeVending.Model
{
    public class Blend : AbstractMachineFunction
    {
        public Blend() : base("Blend")
        {
        }

        internal async override Task Do()
        {
            BLEND();

            await base.Do();
        }

        protected void BLEND()
        {
            //TODO:
        }

        public override string GetLable()
        {
            return $"{Name} ingredients";
        }
    }
}
