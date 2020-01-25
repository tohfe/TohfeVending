using System;
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

    public abstract class AbstractIngredientBasedMachineFunction : AbstractMachineFunction
    {
        public Ingredient Ingredient { get; protected set; }

        public AbstractIngredientBasedMachineFunction(string name, Ingredient ingredient) : base(name)
        {
            Ingredient = ingredient as Ingredient;
        }

        public override string GetLable()
        {
            return $"{Name} {Ingredient.Name.ToLower()}";
        }
    }

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

        async Task Change()
        {
            Container.Set();
        }

        public override string GetLable()
        {
            return null;
            ////return Container.FunctionLabel;
        }
    }

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

    //public class ChangeContainer2<T> : AbstractMachineFunction
    //    where T : IngredientContainer
    //{
    //    public ChangeContainer(T container) : base("ChangeContainer")
    //    {
    //        Container = container;
    //    }

    //    public IngredientContainer Container { get; }

    //    internal async override Task Do()
    //    {
    //        await Change();

    //        await base.Do();
    //    }

    //    async Task Change()
    //    {
    //        Container.Set();
    //    }

    //    public override string GetLable()
    //    {
    //        return Container.FunctionLabel;
    //    }
    //}
}
