using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet.Classes.Transactions
{
    public class FungibleAssetTransaction : Transaction
    {
        public double SenderInitialBalance;
        public double SenderNewBalance;
        public double ReceiverInitialBalance;
        public double ReceiverNewBalance;

        public int AssetQuantity;
        public FungibleAssetTransaction(Asset asset, Wallet senderWallet, Wallet receiverWallet, int assetQuantity)
        {
            Id = Guid.NewGuid();
            AssetAdress = asset.Adress;
            Date = DateTime.Now;
            SenderAdress = senderWallet.Adress;
            ReceiverAdress = receiverWallet.Adress;
            isRevoked = false;
            AssetQuantity = assetQuantity;
        }
    }
}
