﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarketClient {
    public enum TradeFillType { Fill, PartialFill }
    public enum TradeType { Buy, Sell }

    public class TradeHistoryItem {
        public DateTime Time { get; set; }
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
        public decimal Total { get; set; }
        public TradeFillType Fill { get; set;}
        public TradeType Type { get; set; }
        public int Id { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public decimal Current { get; set; }
    }
}
