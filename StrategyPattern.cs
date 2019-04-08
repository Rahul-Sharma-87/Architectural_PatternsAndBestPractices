using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern {
    //Advantage: Each and every alogorithim is option for extension seprately.
    // Methods are not performing more than one resposibilty.
    public interface IStrategy {
        int CalculateCost(Order order);
    }

    /// <summary>
    /// Algorithim for calculating FedEx based delivery cost
    /// </summary>
    public class FedExDeliveryCalculationStrategy : IStrategy {
        public int CalculateCost(Order order) {
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
    }

    /// <summary>
    /// Algorithim for calculating UPS based delivery cost
    /// </summary>
    public class UpsDeliveryCalculationStrategy : IStrategy {
        public int CalculateCost(Order order) {
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
    }

    /// <summary>
    /// Algorithim for calculating USPS based delivery cost
    /// </summary>
    public class UspsDeliveryCalculationStrategy : IStrategy {
        public int CalculateCost(Order order) {
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

    public class StrategyContext {

        private IStrategy strategy;
        public StrategyContext(IStrategy strategy) {
            this.strategy = strategy;
        }
        public int CalculateDeliveryCost(Order order) {
           return this.strategy.CalculateCost(order);
        }
    }

    public class Order {
        public int ItemCount { get; set; }
        public int TotalCost { get; set; }
        public bool IsFragile { get; set; }
        public bool FoodItem { get; set; }
    }
}
