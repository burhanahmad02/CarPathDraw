/*
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;




public class Purchaser : MonoBehaviour, IStoreListener
{
    public static Purchaser instace;
    private static IStoreController m_StoreController;          // The Unity Purchasing system.
    private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.
    public GameObject RemoveAds;
    public GameObject UnlockLevels;
    public GameObject UnlockVehicles;
    //Current project idle business inapps 
    //cash
    public static string Product_Removeads = "com.ultron.roaddraw.hillclimb.removeads";
    public static string Product_Unlocklevels = "com.ultron.roaddraw.hillclimb.unlocklevels";
    public static string Product_UnlockVehicles = "com.ultron.roaddraw.hillclimb.unlockvehicles";
    public static string Product_Firstcash = "com.ultron.roaddraw.hillclimb.firstcash";
    public static string Product_Secondcash = "com.ultron.roaddraw.hillclimb.secondcash";
    public static string Product_Thirdcash = "com.ultron.roaddraw.hillclimb.thirdcash";
    public static string Product_Jumbo = "com.ultron.roaddraw.hillclimb.jumbo";

    void Start()
    {

        instace = this;
        if (m_StoreController == null)
        {

            InitializePurchasing();
        }




        if (PlayerPrefs.GetInt("removeads") > 2)
        {
            RemoveAds.SetActive(false);
        }
        if (PlayerPrefs.GetInt("env" + 1) >= 2 || PlayerPrefs.GetInt("env" + 2) >= 2 || PlayerPrefs.GetInt("env" + 3) >= 2 || PlayerPrefs.GetInt("env" + 4) >= 2)
        {
            UnlockLevels.SetActive(false);
        }



    }

    public void InitializePurchasing()
    {

        if (IsInitialized())
        {

            return;
        }


        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());


        // Add your products here
        builder.AddProduct(Product_Removeads, ProductType.NonConsumable);
        builder.AddProduct(Product_Unlocklevels, ProductType.NonConsumable);
        builder.AddProduct(Product_UnlockVehicles, ProductType.NonConsumable);
        builder.AddProduct(Product_Jumbo, ProductType.NonConsumable);
        builder.AddProduct(Product_Firstcash, ProductType.Consumable);
        builder.AddProduct(Product_Secondcash, ProductType.Consumable);
        builder.AddProduct(Product_Thirdcash, ProductType.Consumable);
        ///////////




        UnityPurchasing.Initialize(this, builder);
    }


    private bool IsInitialized()
    {

        return m_StoreController != null && m_StoreExtensionProvider != null;
    }




    public void Purchase(string purchase)
    {



        if (purchase == "removeads")
        {
            BuyProductID(Product_Removeads);
        }
        else if (purchase == "unlocklevels")
        {
            BuyProductID(Product_Unlocklevels);
        }
        else if (purchase == "unlockvehicle")
        {
            BuyProductID(Product_UnlockVehicles);
        }
        else if (purchase == "jumbo")
        {
            BuyProductID(Product_Jumbo);
        }
        else if (purchase == "first")
        {
            BuyProductID(Product_Firstcash);
        }
        else if (purchase == "second")
        {
            BuyProductID(Product_Secondcash);
        }
        else if (purchase == "third")
        {
            BuyProductID(Product_Thirdcash);
        }
    }



    void BuyProductID(string productId)
    {

        if (IsInitialized())
        {

            Product product = m_StoreController.products.WithID(productId);


            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));

                m_StoreController.InitiatePurchase(product);
            }

            else
            {

                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }

        else
        {

            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }








    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {

        Debug.Log("OnInitialized: PASS");


        m_StoreController = controller;

        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {

        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public void RestorePurchases()
    {

        if (!IsInitialized())
        {
            return;
        }
        if (Application.platform == RuntimePlatform.IPhonePlayer ||
        Application.platform == RuntimePlatform.OSXPlayer)
        {

            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();

            apple.RestoreTransactions((result) =>
            {
              
            });
        }
    }
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {

        if (String.Equals(args.purchasedProduct.definition.id, Product_Removeads, StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("removeads", 3);
            RemoveAds.SetActive(false);
            
        }
        else if (String.Equals(args.purchasedProduct.definition.id, Product_Unlocklevels, StringComparison.Ordinal))
        {
            for (int i = 1; i <= 4; i++)
            {
                PlayerPrefs.SetInt("env" + i, 2);
            }
            UnlockLevels.SetActive(false);
           
        }
        else if (String.Equals(args.purchasedProduct.definition.id, Product_Jumbo, StringComparison.Ordinal))
        {
            for (int i = 1; i <= 4; i++)
            {
                PlayerPrefs.SetInt("env" + i, 2);
            }
            for (int j = 1; j <= 7; j++)
            {
                PlayerPrefs.SetInt("car" + j, 2);
            }

            PlayerPrefs.SetInt("removeads", 3);
            RemoveAds.SetActive(false);
            UnlockLevels.SetActive(false);
            
        }
        else if (String.Equals(args.purchasedProduct.definition.id, Product_UnlockVehicles, StringComparison.Ordinal))
        {

            for (int j = 1; j <= 7; j++)
            {
                PlayerPrefs.SetInt("car" + j, 2);
            }



            UnlockVehicles.SetActive(false);
            
        }
        else if (String.Equals(args.purchasedProduct.definition.id, Product_Firstcash, StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 200000);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, Product_Secondcash, StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 500000);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, Product_Thirdcash, StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 1000000);
        }
        else
        {
            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
        }


        return PurchaseProcessingResult.Complete;
    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {

        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}
*/
