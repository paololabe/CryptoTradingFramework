﻿using CryptoMarketClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Crypto.Core.Strategies {
    [Serializable]
    public class StrategyInputInfo {
        [XmlIgnore]
        public StrategyBase Strategy { get; set; }

        public List<ExchangeInputInfo> Exchanges { get; } = new List<ExchangeInputInfo>();
        public List<TickerInputInfo> Tickers { get; } = new List<TickerInputInfo>();

        public void Assign(StrategyInputInfo info) {
            Exchanges.Clear();
            Tickers.Clear();

            foreach(ExchangeInputInfo e in info.Exchanges) {
                Exchanges.Add((ExchangeInputInfo)e.Clone());
            }
            foreach(TickerInputInfo t in info.Tickers) {
                Tickers.Add((TickerInputInfo)t.Clone());
            }
        }
    }

    [Serializable]
    public class ExchangeInputInfo : ICloneable {
        public ExchangeType ExchangeType { get; set; }
        [XmlIgnore]
        public Exchange Exchange { get; set; }

        public object Clone() {
            return new ExchangeInputInfo() { ExchangeType = this.ExchangeType, Exchange = this.Exchange };
        }
    } 

    [Serializable]
    public class TickerInputInfo : ICloneable {
        public TickerInputInfo() { }
        public TickerInputInfo(string currencyPair, bool needOrderBook, bool needTradeHistory, bool needKline) {
            TickerName = currencyPair;
            UseOrderBook = needOrderBook;
            UseTradeHistory = needTradeHistory;
            UseKline = needKline;
        }
        public ExchangeType Exchange { get; set; }
        [XmlIgnore]
        public Ticker Ticker { get; set; }
        public string TickerName { get; set; }
        public bool UseOrderBook { get; set; }
        public bool UseTradeHistory { get; set; }
        public bool UseKline { get; set; }
        public int KlineIntervalMin { get; set; }

        public object Clone() {
            return new TickerInputInfo() {
                Exchange = this.Exchange,
                Ticker = this.Ticker,
                TickerName = this.TickerName,
                UseOrderBook = this.UseOrderBook,
                UseTradeHistory = this.UseTradeHistory,
                UseKline = this.UseKline,
                KlineIntervalMin = this.KlineIntervalMin
            };
        }
    }
}