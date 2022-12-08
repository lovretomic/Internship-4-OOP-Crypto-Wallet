using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet.Classes.Wallets
{
    public class SolanaWallet : Wallet
    {
        public SolanaWallet(bool isCreatedByUser, List<Asset>? defaultFungibleAssets, List<Asset>? defaultNonFungibleAssets)
        {
            Adress = Guid.NewGuid();
            WalletType = Enums.WalletType.SOL;
            IsCreatedByUser = isCreatedByUser;

            if (defaultFungibleAssets is not null)
                for (int i = 0; i < defaultFungibleAssets.Count(); i++)
                    FungibleAssets.Add(defaultFungibleAssets[i].Adress, getRandomInt());
            

            if (defaultNonFungibleAssets is not null)
                for (int i = 0; i < defaultNonFungibleAssets.Count(); i++)
                    NonFungibleAssets.Add(defaultNonFungibleAssets[i].Adress);
        }

        public override void getTotalAssetValue()
        {
            double totalValue = 0;
            foreach (var privateAsset in FungibleAssets)
                foreach (var supportedAsset in SupportedAssets)
                    if (privateAsset.Key == supportedAsset.Adress)
                        totalValue += privateAsset.Value * supportedAsset.ValueUSD;

            foreach (var privateAsset in NonFungibleAssets)
                foreach (var supportedAsset in SupportedAssets)
                    if (privateAsset == supportedAsset.Adress)
                        totalValue += supportedAsset.ValueUSD;

            TotalAssetValue = totalValue;
        }

        private int getRandomInt()
        {
            Random random = new Random();
            return random.Next(1, 5);
        }
    }
}
