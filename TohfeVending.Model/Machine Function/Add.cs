using System;
using System.Threading.Tasks;

namespace TohfeVending.Model
{
    public class Add : AbstractIngredientBasedMachineFunction
    {
        public Add(IAddable ingredient) : base("Add", ingredient as AddableIngredient)
        {
            Addable = ingredient;
            label = PrepareLabel();
        }

        protected Add(string name, AddableIngredient ingredient) : base(name, ingredient)
        {
            Addable = ingredient;

            label = PrepareLabel();
        }

        IAddable Addable { get; set; }

        internal async override Task Do()
        {
            ADD();

            await base.Do();
        }
        protected virtual void ADD()
        {
            //TODO:
            VendingMachine.Instance.CurrentIngredientContainer.Add(Ingredient as AddableIngredient);
        }

        string label = null;

        string PrepareLabel()
        {
            var cn = VendingMachine.Instance.CurrentIngredientContainer;

            if (cn == IngredientContainer.Cup)
                return $"{Name} {Addable.Name.ToLower()}";
            else if (cn == IngredientContainer.Blender)
                return $"{Name} {Addable.Name.ToLower()}{$" to {cn?.Name.ToLower()}"}";
            else if (cn == null)
            {
                if (VendingMachine.Instance.VendingMachineStatus == VendingMachineStatusType.StandBy) return "-";

                return null;
            }

            throw new NotImplementedException();
        }
        public override string GetLable() => label;
    }
}
