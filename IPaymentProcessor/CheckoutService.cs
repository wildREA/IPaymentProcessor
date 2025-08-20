using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor_Interface
{
    internal class CheckoutService
    {
        private readonly IPaymentProcessor _paymentProcessor;
        public CheckoutService(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }
        public string Process(decimal amount)
        {
            return _paymentProcessor.Process(amount);
        }
    }
}
