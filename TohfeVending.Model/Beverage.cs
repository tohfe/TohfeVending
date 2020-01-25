using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TohfeVending.Model
{
    public class Beverage
    {
        public string Name { get; private set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<AbstractMachineFunction> ProcessesInOrder { get; set; }
        public Beverage(string name)
        {
            Name = name;
        }

        public async Task Make()
        {
            await Services.GetMachine().Make(this);
        }

        public static Beverage Hot_Chocolate = new Beverage("Hot Chocolate")
        {
            Ingredients = new List<Ingredient>(new Ingredient[]{
                Ingredient.Water,
                Ingredient.Drinking_Chocolate
            }),
            ProcessesInOrder = new List<AbstractMachineFunction>(new AbstractMachineFunction[] {
                new ChangeContainer(IngredientContainer.Cup),
                new Boil(Ingredient.Water),
                new Add(Ingredient.Drinking_Chocolate),
                new Add(Ingredient.Water),
            }),
        };
        public static Beverage White_Coffee = new Beverage("White Coffee")
        {
            Ingredients = new List<Ingredient>(new Ingredient[]{
                Ingredient.Water,
                Ingredient.Drinking_Chocolate
            }),
            ProcessesInOrder = new List<AbstractMachineFunction>(new AbstractMachineFunction[] {
                new ChangeContainer(IngredientContainer.Cup),
                new Boil(Ingredient.Water),
                new Add(Ingredient.Sugar),
                new Add(Ingredient.Coffee_Granules),
                new Add(Ingredient.Water),
                new Add(Ingredient.Milk),
            })
        };
        public static Beverage Iced_Coffee = new Beverage("Iced Coffee")
        {
            Ingredients = new List<Ingredient>(new Ingredient[]{
                Ingredient.Ice, Ingredient.Coffee_Syrup
            }),
            ProcessesInOrder = new List<AbstractMachineFunction>(new AbstractMachineFunction[] {
                new ChangeContainer(IngredientContainer.Blender),
                new Crush(Ingredient.Ice),
                new Add(Ingredient.Ice),
                new Add(Ingredient.Coffee_Syrup),
                new Blend(),
                new ChangeContainer(IngredientContainer.Cup),
                new Add(IngredientContainer.Blender),
            })
        };
        public static Beverage Lemon_Tea = new Beverage("Lemon Tea")
        {
            Ingredients = new List<Ingredient>(new Ingredient[]{
                Ingredient.Ice, Ingredient.Drinking_Chocolate
            }),
            ProcessesInOrder = new List<AbstractMachineFunction>(new AbstractMachineFunction[] {
                new ChangeContainer(IngredientContainer.Cup),
                new Boil(Ingredient.Water),
                new Add(Ingredient.Water),
                new Steep(Ingredient.Tea_Bag),
                new Add(Ingredient.Lemon),
            })
        };
    }
}
