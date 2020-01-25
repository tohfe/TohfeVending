namespace TohfeVending.Model
{
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
}
