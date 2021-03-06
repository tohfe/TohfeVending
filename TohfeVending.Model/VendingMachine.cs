﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TohfeVending.Model
{
    public enum VendingMachineStatusType { StandBy, InProgress }

    public class VendingMachine
    {
        static VendingMachine instance;
        public static VendingMachine Instance => instance ?? (instance = new VendingMachine());

        public event EventHandler<AbstractMachineFunction> OnFunctionStart;
        public event EventHandler<AbstractMachineFunction> OnFunctionDone;
        public event EventHandler<Beverage> OnMakingDone;

        private VendingMachineStatusType internalVendingMachineStatus = VendingMachineStatusType.StandBy;
        public VendingMachineStatusType VendingMachineStatus { get => internalVendingMachineStatus; }
        void SetMachineStatus(VendingMachineStatusType status) => internalVendingMachineStatus = status;

        public UserData CurrentUser { get; set; }
        public IngredientContainer CurrentIngredientContainer { get; set; }
        public List<Beverage> Beverages { get; private set; }
        public List<Ingredient> Ingredients { get; private set; }

        VendingMachine()
        {
            InitlizeData();

            CurrentUser = Services.GetUsers()[2];
        }

        void InitlizeData()
        {
            InitializeIngredients();

            InitializeBeverages();
        }
        void InitializeIngredients()
        {
            Ingredients = new List<Ingredient>();

            Ingredients.Add(Ingredient.Water);
            Ingredients.Add(Ingredient.Sugar);
            Ingredients.Add(Ingredient.Milk);
            Ingredients.Add(Ingredient.Lemon);
            Ingredients.Add(Ingredient.Coffee_Granules);
            Ingredients.Add(Ingredient.Drinking_Chocolate);
            Ingredients.Add(Ingredient.Coffee_Syrup);
            Ingredients.Add(Ingredient.Tea_Bag);
        }
        void InitializeBeverages()
        {
            Beverages = new List<Beverage>();

            Beverages.Add(Beverage.Hot_Chocolate);
            Beverages.Add(Beverage.White_Coffee);
            Beverages.Add(Beverage.Iced_Coffee);
            Beverages.Add(Beverage.Lemon_Tea);
        }

        internal async Task Make(Beverage beverage)
        {
            while (!IsStandBy) ;

            SetMachineStatus(VendingMachineStatusType.InProgress);

            foreach (var process in beverage.ProcessesInOrder)
            {
                if (IsStandBy) break;

                OnFunctionStart?.Invoke(this, process);

                if (IsStandBy) break;

                await process.Do();

                if (IsStandBy) break;

                OnFunctionDone?.Invoke(this, process);
            }

            SetMachineStatus(VendingMachineStatusType.StandBy);

            OnMakingDone?.Invoke(this, beverage);
        }

        bool IsStandBy => VendingMachineStatus == VendingMachineStatusType.StandBy;

        public async Task Restart()
        {
            SetMachineStatus(VendingMachineStatusType.StandBy);
        }
        public async Task Stop()
        {
            SetMachineStatus(VendingMachineStatusType.StandBy);
        }
    }
}
