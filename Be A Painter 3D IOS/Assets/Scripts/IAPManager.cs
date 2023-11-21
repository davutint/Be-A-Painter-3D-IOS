using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using TMPro;
using System;
using Unity.Services.Core;
using Unity.Services.Core.Environments;

public class IAPManager : MonoBehaviour,IStoreExtension
{
    public MarketManager2 marketManager2;
    public static string canvas5premium = "com.PixiCorp.BeAPainter3D.premiumcanvas1";
    
    

    public void OnPurchaseComplate(Product product)
    {
        // Eğer gelen ürün id'si bizim sistemde tanımladığımız id'mize eşitse, satın alınan ürünü oyuncuya
        // verme yeri burasıdır. Burada ki amaç hangi ürünü satın aldığını anlamaktır.
        if (product.definition.id==canvas5premium)
        {
            PlayerPrefs.SetInt("canvas5aldı", 5);
          
            PlayerPrefs.Save();

            marketManager2.premiumbutonac();
        }

    }

    public void OnPurchaseFailed(Product product,PurchaseFailureReason reason)
    {
        Debug.Log(product + "alırken şu hata oldu" + reason);

    }


}

