﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet.Classes
{
    public abstract class Asset
    {
        public Guid Adress;
        public string Name;
        public decimal ValueUSD;
    }
}