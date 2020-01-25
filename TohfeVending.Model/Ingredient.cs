namespace TohfeVending.Model
{
    public class Ingredient
    {
        public string Name { get; set; }
        public Ingredient(string name)
        {
            Name = name;
        }


        public static AddableIngredient Water = new AddableIngredient("Water");
        public static AddableIngredient Sugar = new AddableIngredient("Sugar");
        public static AddableIngredient Milk = new AddableIngredient("Milk");
        public static AddableIngredient Lemon = new AddableIngredient("Lemon");
        public static AddableIngredient Coffee_Granules = new AddableIngredient("Coffee Granules");
        public static AddableIngredient Drinking_Chocolate = new AddableIngredient("Drinking Chocolate");
        public static AddableIngredient Coffee_Syrup = new AddableIngredient("Coffee Syrup");
        public static Ingredient Tea_Bag = new Ingredient("Tea Bag");
        public static AddableIngredient Ice = new AddableIngredient("Ice");
    }
    public class AddableIngredient : Ingredient, IAddable
    {
        public AddableIngredient(string name) : base(name)
        {
        }

        public void Add(IngredientContainer container)
        {
            //TODO:
        }
    }
}
