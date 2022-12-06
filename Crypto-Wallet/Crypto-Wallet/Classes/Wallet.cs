using Crypto_Wallet.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet.Classes
{
    public abstract class Wallet
    {
        public Guid Adress;
        public Dictionary<string, int> fungibleAssetsBalances;
        public List<Guid> Transactions;
        public WalletType WalletType;

        public Dictionary<Guid, int> FungibleAssets = new Dictionary<Guid, int>();
        public List<Guid> NonFungibleAssets = new List<Guid>();
        public List<Asset> SupportedAssets;
        public double TotalAssetValue;

        public int TimesAccessed = 0;
        public double LastAccessedTotalAssetValue;

        public bool IsCreatedByUser;

        public void printData()
        {
            Console.WriteLine($"TIP : {WalletType}");
            Console.WriteLine($"ADRESA : {Adress}");
            getTotalAssetValue();
            Console.WriteLine($"UKUPNA VRIJEDNOST ASSETA : {TotalAssetValue} USD");
            if(TimesAccessed != 0)
                Console.WriteLine($"PROMIJENA UKUPNE VRIJEDNOSTI ASSETA : {(TotalAssetValue - LastAccessedTotalAssetValue) / LastAccessedTotalAssetValue * 100}%");
            Console.WriteLine("----------");
            TimesAccessed++;
            LastAccessedTotalAssetValue = TotalAssetValue;
        }

        public virtual void getTotalAssetValue() {
            double totalValue = 0;
            foreach (var privateAsset in FungibleAssets)
                foreach (var supportedAsset in SupportedAssets)
                    if (privateAsset.Key == supportedAsset.Adress)
                        totalValue += privateAsset.Value * supportedAsset.ValueUSD;
            TotalAssetValue = totalValue;
            if (TimesAccessed is 0) LastAccessedTotalAssetValue = totalValue;
        }
    }
}
