using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern {
    //Illustrate Problem Statement without Strategy Pattern
    class Program {
        //1. Stategy Pattern is useful to avoid switch statements. So that it doesnt voilate OCP. 
        //2. Logic of the Algorithim evolves seprately.
        //3. Maintains single purpose.
        static void Main(string[] args)
        {
            Program context = new Program();
            Order order = new Order() {IsFragile = true, ItemCount = 3, TotalCost = 100};
            context.CalculateDeliveryCost(order,"FedEx");
            // This implementation doesn't allow adding new delivery option without modifying class
            // Also user need to pass delivery option but instead it must depend on internal business logic

        }
        public int CalculateDeliveryCost(Order order,string deliveryOption) {
            int deliveryCost;
            switch (deliveryOption) {
                case "FedEx":
                    deliveryCost = CalculateCostForFedEx(order);
                    break;
                case "UPS":
                    deliveryCost = CalculateCostForUPS(order);
                    break;
                case "USPS":
                    deliveryCost = CalculateCostForUSPS(order);
                    break;
                default:
                    throw new NotSupportedException();
            }
            return deliveryCost;
        }

        private int CalculateCostForFedEx(Order order) {
            int baseCost = 10 * order.ItemCount;
            if (order.TotalCost > 1000) {
                // For insurance
                baseCost += 25;
            }

            if (order.IsFragile) {
                baseCost += 5;
            }

            if (order.FoodItem) {
                baseCost += 5;
            }
            return baseCost;
        }

        private int CalculateCostForUPS(Order order) {
            int baseCost = 10 * order.ItemCount;
            if (order.TotalCost > 1000) {
                // For insurance
                baseCost += 25;
            }
            if (order.IsFragile) {
                baseCost += 5;
            }
            return baseCost;
        }

        private int CalculateCostForUSPS(Order order) {
            int baseCost = 10 * order.ItemCount;
            if (order.TotalCost > 1000) {
                // For insurance
                baseCost += 15;
            }
            if (order.IsFragile) {
                baseCost += 5;
            }

            if (order.FoodItem) {
                throw new InvalidOperationException("Food items cannot be deliverd");
            }
            return baseCost;
        }


        
    }
    public class Order {
        public int ItemCount { get; set; }
        public int TotalCost { get; set; }
        public bool IsFragile { get; set; }
        public bool FoodItem { get; set; }
    }
}
