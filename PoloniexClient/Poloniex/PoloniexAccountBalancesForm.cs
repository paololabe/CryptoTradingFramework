﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoMarketClient.Poloniex {
    public partial class PoloniexAccountBalancesForm : ThreadUpdateForm {
        public PoloniexAccountBalancesForm() {
            InitializeComponent();
            this.poloniexAccountBalanceInfoBindingSource.DataSource = PoloniexExchange.Default.Balances;
        }

        protected override int UpdateInervalMs => 3000;
        protected override bool AllowUpdateInactive => false;

        protected override void OnThreadUpdate() {
            if(!PoloniexExchange.Default.IsConnected)
                return;
            UpdateBalances();
        }
        void UpdateBalances() {
            PoloniexExchange.Default.UpdateBalances();
            PoloniexExchange.Default.GetDeposits();
            this.gridControl1.RefreshDataSource();
        }
    }
}
