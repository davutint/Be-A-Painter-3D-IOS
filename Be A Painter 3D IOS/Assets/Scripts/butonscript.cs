using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class butonscript : MonoBehaviour
{
   
    
    public GameObject[] MarketObjeleri;
    public GameObject[] bilgiobjleri;
    public GameObject[] BilgiTexts;

    
    public GameObject[] Eserler;
    public AudioSource kötüresimses;
    public AudioSource iyiresimses;
    public AudioSource buttonsound;
   
    #region CANVAS SATIN ALMA BUTONLARI

    public void BoyaSatınAl()
    {
        GameManager.instance.Buy(50);
        GameManager.instance.BoyaSayısı += 50;
        PlayerPrefs.SetInt("boya", GameManager.instance.BoyaSayısı);
    }

    #endregion

    public void marketıac() // open market
    {
        buttonsound.Play();
        GameManager.instance.GetMarket();
       
    }


    public void Restart()
    {
        buttonsound.Play();
        SceneManager.LoadScene(1);
    }

    public void İnformationFonksiyonu(int objindex)
    {
        bilgiobjleri[objindex].GetComponent<Image>().DOFade(1, .5f);
        BilgiTexts[objindex].SetActive(true);
        MarketObjeleri[objindex].GetComponent<Image>().DOFade(0, .5f).OnComplete(() =>
         {
             StartCoroutine(MarketBigliyiKapat(objindex));
         });
         


    }

    IEnumerator MarketBigliyiKapat(int objindex)
    {
        yield return new WaitForSeconds(2);
        BilgiTexts[objindex].SetActive(false);
        bilgiobjleri[objindex].GetComponent<Image>().DOFade(0, .5f).OnComplete(() =>
        {
            MarketObjeleri[objindex].GetComponent<Image>().DOFade(1, .5f);
        });

    }

    public void AnamenuAc()
    {
        buttonsound.Play();
        SceneManager.LoadScene(0);
    }






    #region MARKET SATIŞ BUTONLARI

    public void Cubuk1Sell()
    {
        GameManager.instance.cubuk1adt = PlayerPrefs.GetInt("cubuk1adt");
        if (GameManager.instance.cubuk1adt< 1)
        {
            Eserler[0].SetActive(false);
            
        }
        else
        {
          
            PlayerPrefs.SetInt("cubuk1adt",PlayerPrefs.GetInt("cubuk1adt")-1);
            GameManager.instance.SellFonk(25);
            kötüresimses.Play();
            GameManager.instance.EserAdtPf();
            GameManager.instance.ArtCountTextUpdate();
            if (GameManager.instance.cubuk1adt < 1)
            {
                Eserler[0].SetActive(false);

            }


        }
        
    }
    public void Cubuk2Sell()
    {
        GameManager.instance.cubuk2adt = PlayerPrefs.GetInt("cubuk2adt");
        if (GameManager.instance.cubuk2adt< 1)
        {
            Eserler[1].SetActive(false);
            
        }
        else
        {

         
            PlayerPrefs.SetInt("cubuk2adt", PlayerPrefs.GetInt("cubuk2adt")-1);
            GameManager.instance.SellFonk(25);
            kötüresimses.Play();
            GameManager.instance.EserAdtPf();
            GameManager.instance.ArtCountTextUpdate();
            if (GameManager.instance.cubuk2adt < 1)
            {
                Eserler[1].SetActive(false);

            }

        }
       
    }
    public void Cubuk3Sell()
    {
        GameManager.instance.cubuk3adt = PlayerPrefs.GetInt("cubuk3adt");
        if (GameManager.instance.cubuk3adt <1)
        {
            Eserler[2].SetActive(false);
        }
        else
        {
            
            PlayerPrefs.SetInt("cubuk3adt",PlayerPrefs.GetInt("cubuk3adt")-1);
            GameManager.instance.SellFonk(25);
            kötüresimses.Play();
            GameManager.instance.EserAdtPf();
            GameManager.instance.ArtCountTextUpdate();
            if (GameManager.instance.cubuk3adt < 1)
            {
                Eserler[2].SetActive(false);
            }


        }
        
    }
    public void Cubuk4Sell()
    {
        GameManager.instance.cubuk4adt = PlayerPrefs.GetInt("cubuk4adt");
        if (GameManager.instance.cubuk4adt< 1)
        {
            Eserler[3].SetActive(false);
        }
        else
        {
            
            PlayerPrefs.SetInt("cubuk4adt",PlayerPrefs.GetInt("cubuk4adt")-1);
            GameManager.instance.SellFonk(25);
            kötüresimses.Play();
            GameManager.instance.EserAdtPf();
            GameManager.instance.ArtCountTextUpdate();
            if (GameManager.instance.cubuk4adt < 1)
            {
                Eserler[3].SetActive(false);
            }

        }
        
    }
    public void Nadir1Sell()
    {
        GameManager.instance.nadir1adt = PlayerPrefs.GetInt("nadir1adt");


        if (GameManager.instance.nadir1adt<1)
        {
            Eserler[4].SetActive(false);
        }
        else
        {
            
            PlayerPrefs.SetInt("nadir1adt", PlayerPrefs.GetInt("nadir1adt")-1);
            GameManager.instance.SellFonk(250);
            iyiresimses.Play();
            GameManager.instance.EserAdtPf();
            GameManager.instance.ArtCountTextUpdate();
            if (GameManager.instance.nadir1adt < 1)
            {
                Eserler[4].SetActive(false);
            }


        }
        
    }
    public void Nadir2Sell()
    {
        GameManager.instance.nadir2adt = PlayerPrefs.GetInt("nadir2adt");
        if (GameManager.instance.nadir2adt < 1)
        {
            Eserler[5].SetActive(false);
        }
        else
        {
            
            PlayerPrefs.SetInt("nadir2adt", PlayerPrefs.GetInt("nadir2adt")-1);
            GameManager.instance.SellFonk(250);
            GameManager.instance.EserAdtPf();
            GameManager.instance.ArtCountTextUpdate();
            iyiresimses.Play();
            if (GameManager.instance.nadir2adt < 1)
            {
                Eserler[5].SetActive(false);
            }

        }
        
    }

    #endregion

    public void BackButton()
    {
        buttonsound.Play();
        GameManager.instance.LostArtMarket();

    }

    public void ArtMarketiGetir()
    {
        buttonsound.Play();
        GameManager.instance.GetArtMarket();
    }

    public void MarketKapaMenuAc()
    {
        buttonsound.Play();
        GameManager.instance.MarketKapaMenüAc();
    }

    
}
