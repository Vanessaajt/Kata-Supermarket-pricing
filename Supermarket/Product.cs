﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public class Product
    {
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public PricingRules ProductRule { get; set; }

    }
}
