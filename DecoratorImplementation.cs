using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test {

    public interface Pizza {
        int GetCost();

        string GetDescription();
    }

    #region Concrete Pizza

    public class SmallPizza: Pizza{

        public int GetCost( ) {
            return 10;
        }

        public string GetDescription()
        {
            return "SmallPizza";
        }
    }

    public class MediumPizza: Pizza {
        public int GetCost( ) {
            return 20;
        }

        public string GetDescription()
        {
            return "MediumPizza";
        }
    }

    public class LargePizza: Pizza {
        public int GetCost( ) {
            return 30;
        }

        public string GetDescription()
        {
            return "LargePizza";
        }
    }

    #endregion

    public class PizzaDecorator:Pizza {
        private Pizza _pizza;
        public PizzaDecorator(Pizza pizza) {
            _pizza = pizza;
        }

        public virtual int GetCost( ) {
            return _pizza.GetCost();
        }

        public virtual string GetDescription() {
            return _pizza.GetDescription();
        }
    }

    #region ConreateDecorator
    public class CheeseDecorator : PizzaDecorator
    {
        public CheeseDecorator(Pizza pizza):base(pizza) {
        }

        public override int GetCost( ) {
           return base.GetCost() + 5;
        }

        public override string  GetDescription( )
        {
            return " Cheese " + base.GetDescription();
        }
    }

    public class GardenFreshDecorator : PizzaDecorator
    {
        public GardenFreshDecorator(Pizza pizza):base(pizza) {
        }

        public override int GetCost( ) {
            return base.GetCost() + 7;
        }

        public override string  GetDescription( )
        {
            return " GardenFresh " + base.GetDescription();
        }
    }
    #endregion
}

//Usage of Decorator

            LargePizza largePizza = new LargePizza();

            //
            var decorator = new CheeseDecorator(largePizza);

            var cost = decorator.GetCost();

            Console.WriteLine(decorator.GetDescription()+ cost);

            //
            var decorator1 = new GardenFreshDecorator(largePizza);

            var cost1 = decorator1.GetCost();

            Console.WriteLine(decorator1.GetDescription()+ cost1);

            //
            var decorator2 = new CheeseDecorator(decorator1);

            var cost2 = decorator2.GetCost();

            Console.WriteLine(decorator2.GetDescription()+ cost2);
