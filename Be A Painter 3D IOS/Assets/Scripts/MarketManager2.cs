using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class MarketManager2 : MonoBehaviour
{
    public GameObject[] MarketObjeleri;
    public GameObject[] bilgiobjleri;
    public GameObject[] BilgiTexts;


    public GameObject Market;
    public Button[] CanvasBuys;
    public int canvas1, canvas2, canvas3, canvas4, canvas5;
    [SerializeField]
    private int para;
    public TextMeshProUGUI Para;
    public int Boyasayısı;

    public TextMeshProUGUI BoyasayısıText;

    public GameObject premiumbuton;

    public AudioSource buttonsound;

    public AudioSource satınalses;
    private void Awake()
    {
        Boyasayısı = PlayerPrefs.GetInt("boya");
        if (Boyasayısı <= 0)
            PlayerPrefs.SetInt("boya", 50);
    }
    void Start()
    {
        PlayerPrefs.SetInt("canvas1aldı", 1);
        para = PlayerPrefs.GetInt("para");
        Para.SetText(para.ToString()+"  $");
        MarketTextCheck();
        
    }

  
    public void marketsatınalma()     //canvasın daha önce satın alınıp alınmadığını bilmek için bir playerprefs ayarla ve onun kontrolünü yap;
    {
        buttonsound.Play();
        int marketkontrol = PlayerPrefs.GetInt("canvas1aldı");
        if (marketkontrol != 1)
        {
            if (para >= 1000)
            {
                PlayerPrefs.SetInt("canvas1aldı", 1);
                SatınAl(1000); //burayı butonların yazısını kontrol etmek için kullacaksın; diğerlerine de yap...
                MarketTextCheck();
            }
            //else kısmına butonu kırmızıya döndür sonra eski haline dönsün;

        }
        else// daha önce aldıysa burası çalışmalı ancak butonda select yazmalı burada yazılı olanları menü geldiğinde veya oyun bittiğinde kontrol etmeliyiz;
        {   //ardından burada satın aldıktan sonra da yazı değilmeli.Gamemanagerde fonsiyon yaz hem satın alınca hemce oyun bitince çalışsın .
            PlayerPrefs.SetInt("marketsatınaldı", 1);
            MarketKapa();
        }

    }


    public void marketsatınalma2()
    {
        buttonsound.Play();
        int marketkontrol = PlayerPrefs.GetInt("canvas2aldı");
        if (marketkontrol != 2)
        {
            if (para >= 1500)
            {
                PlayerPrefs.SetInt("canvas2aldı", 2);
                SatınAl(1500);
                MarketTextCheck();

            }

        }
        else
        {
            PlayerPrefs.SetInt("marketsatınaldı", 2);
            MarketKapa();
        }



    }
    public void premiumbutonac()
    {
        buttonsound.Play();
        premiumbuton.SetActive(true);
    }

    public void marketsatınalma3()
    {
        buttonsound.Play();
        int marketkontrol = PlayerPrefs.GetInt("canvas3aldı");
        if (marketkontrol != 3)
        {
            if (para >= 2000)
            {
                PlayerPrefs.SetInt("canvas3aldı", 3);
                SatınAl(2000);
                MarketTextCheck();

            }

        }
        else
        {
            PlayerPrefs.SetInt("marketsatınaldı", 3);
            MarketKapa();
        }



    }

    public void marketsatınalma4()
    {
        buttonsound.Play();

        int marketkontrol = PlayerPrefs.GetInt("canvas4aldı");
        if (marketkontrol != 4)
        {
            if (para >= 2500)
            {
                PlayerPrefs.SetInt("canvas4aldı", 4);
                SatınAl(2500);
                MarketTextCheck();
                
            }


        }
        else
        {
            PlayerPrefs.SetInt("marketsatınaldı", 4);
            MarketKapa();
        }



    }

    public void premiumCanvas()
    {
        buttonsound.Play();
        PlayerPrefs.SetInt("marketsatınaldı", 5);
        MarketKapa();
    }

    public void BoyaSatınAl()
    {
        buttonsound.Play();
        if (para >= 50)
        {
            PlayerPrefs.SetInt("boya", PlayerPrefs.GetInt("boya") + 50);
            SatınAl(50);
        }
       
    }

    public void MarketAc()
    {
        buttonsound.Play();
        Market.transform.DOLocalMove(new Vector3(0, 0, 0), .3f);
    }
    public void MarketKapa()
    {
        buttonsound.Play();
        Market.transform.DOLocalMove(new Vector3(-3000, 0, 0),.3f);
    }


    public void SatınAl(int fiyat)
    {
        satınalses.Play();
        para -= fiyat;
        Para.SetText(para.ToString()+" $");
        PlayerPrefs.SetInt("para", para);
    }

   

    void MarketTextCheck()
    {
       
        canvas1 = PlayerPrefs.GetInt("canvas1aldı");
        canvas2 = PlayerPrefs.GetInt("canvas2aldı");
        canvas3 = PlayerPrefs.GetInt("canvas3aldı");
        canvas4 = PlayerPrefs.GetInt("canvas4aldı");
        canvas5 = PlayerPrefs.GetInt("canvas5aldı");

        if (canvas1 == 1)
        {
            CanvasBuys[0].GetComponentInChildren<TextMeshProUGUI>().SetText("Select");
        }

        if (canvas2 == 2)
        {
            CanvasBuys[1].GetComponentInChildren<TextMeshProUGUI>().SetText("Select");
        }

        if (canvas3 == 3)
        {
            CanvasBuys[2].GetComponentInChildren<TextMeshProUGUI>().SetText("Select");
        }

        if (canvas4 == 4)
        {
            CanvasBuys[3].GetComponentInChildren<TextMeshProUGUI>().SetText("Select");
        }


        if (canvas5 == 5)
        {
            premiumbuton.SetActive(true);
            
        }



    }



    public void İnformationFonksiyonu(int objindex)
    {

        MarketObjeleri[objindex].GetComponent<Image>().DOFade(0, .5f).OnComplete(() =>
        {

            bilgiobjleri[objindex].GetComponent<Image>().DOFade(1, .5f);
            BilgiTexts[objindex].SetActive(true);
            StartCoroutine(MarketBigliyiKapat(objindex));
        });

    }

    public void BoyaBilgi()
    {
        Boyasayısı = PlayerPrefs.GetInt("boya");
        MarketObjeleri[5].GetComponent<Image>().DOFade(0, .5f).OnComplete(() =>
        {
            BoyasayısıText.SetText("Paint Count:  "+Boyasayısı.ToString());
            bilgiobjleri[5].GetComponent<Image>().DOFade(1, .5f);
            BilgiTexts[5].SetActive(true);
            StartCoroutine(MarketBigliyiKapat(5));
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

}
