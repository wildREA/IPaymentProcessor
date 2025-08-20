using Microsoft.Extensions.DependencyInjection;

namespace PaymentProcessor_Interface
{
    public interface IPaymentProcessor
    {
        string Process(decimal amount);
    }

    public class PaymentProcessor : IPaymentProcessor
    {
        public string Process(decimal amount)
        {
            return $"Processing payment of {amount:C}";
        }
    }

    public class StripePaymentProcessor : IPaymentProcessor
    {
        public string Process(decimal amount)
        {
            return $"Processing Stripe payment of {amount:C}";
        }
    }

    public class PayPalPaymentProcessor : IPaymentProcessor
    {
        public string Process(decimal amount)
        {
            return $"Processing PayPal payment of {amount:C}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            
            Console.WriteLine("Choose a payment processor (PayPal / Stripe):");
            var register = Console.ReadLine()?.ToLowerInvariant();
            
            switch (register)
            {
                case "paypal":
                    serviceCollection.AddTransient<IPaymentProcessor, PayPalPaymentProcessor>();
                    break;
                case "stripe":
                    serviceCollection.AddTransient<IPaymentProcessor, StripePaymentProcessor>();
                    break;
                default:
                    Console.WriteLine("Invalid payment processor specified.");
                    return;
            }

            serviceCollection.AddTransient<CheckoutService>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var checkoutService = serviceProvider.GetRequiredService<CheckoutService>();
            Console.WriteLine(checkoutService.Process(100));
        }
    }
}
