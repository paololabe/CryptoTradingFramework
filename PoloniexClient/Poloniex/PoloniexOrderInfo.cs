﻿using CryptoMarketClient.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarketClient.Poloniex {
    public class PoloniexOrderInfo {
        public string Market { get; set; }
        public int OrderNumber { get; set; }
        public OrderType Type { get; set; }
        public decimal Value { get; set; }
        public decimal Amount { get; set; }
        public decimal Total { get; set; }
    }
}
