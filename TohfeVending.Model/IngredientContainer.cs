using System;

namespace TohfeVending.Model
{
    public abstract class IngredientContainer
    {
        public abstract string Name { get; }

        internal void Set()
        {
            Services.GetMachine().CurrentIngredientContainer = this;
        }

        internal void Add(AddableIngredient ingredient)
        {
            //TODO:
        }

        public static Cup Cup { get; set; } = new Cup();
        public static Blender Blender { get; set; } = new Blender();
    }
    public class Cup : IngredientContainer
    {
        public override string Name => null;
    }
    public class Blender : IngredientContainer, IAddable
    {
        public override string Name => "Blender";

        string IAddable.Name { get => "ingredients"; }

        public void Add(IngredientContainer container)
        {
            //TODO:
        }
    }
}
