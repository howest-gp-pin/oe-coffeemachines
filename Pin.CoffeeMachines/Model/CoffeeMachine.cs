﻿using System.ComponentModel.DataAnnotations;

namespace Pin.CoffeeMachines.Model
{
    public class CoffeeMachine : Machine
    {
        public bool HasBeans { get; set; }
    }
}
