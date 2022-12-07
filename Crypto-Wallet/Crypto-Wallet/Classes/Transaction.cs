using Crypto_Wallet.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet.Classes
{
    public abstract class Transaction
    {
        public Guid Id;
        public Guid AssetAdress;
        public DateTime Date;
        public Guid SenderAdress;
        public Guid ReceiverAdress;
        public bool isRevoked;
        public AssetType TransactionType;
        public int AssetQuantity;
    }
}
