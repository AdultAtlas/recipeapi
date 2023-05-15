using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class WeightDTO
    {
        public double Amount { get; private set; }
        public string Symbol { get; private set; }

        public WeightDTO(double amount, string symbol)
        {
            Amount = amount;
            Symbol = symbol;
        }
    }
}
