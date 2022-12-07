using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet.Classes.Transactions
{
    public class NonFungibleAssetTransaction : Transaction
    {
        public NonFungibleAssetTransaction(Asset asset, Wallet senderWallet, Wallet receiverWallet)
        {
            Id = Guid.NewGuid();
            AssetAdress = asset.Adress;
            Date = DateTime.Now;
            SenderAdress = senderWallet.Adress;
            ReceiverAdress = receiverWallet.Adress;
            isRevoked = false;
            TransactionType = Enums.AssetType.NONFUNGIBLE;
        }
    }
}
