using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
using Apple.GameKit.Leaderboards;
using Apple.GameKit;
using Apple.GameKit.Multiplayer;
using System.Linq;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{

    public AudioSource KötüresimMüzik;
    
    public AudioSource İyiResimMüzik;

    public AudioSource buttonsound;

    public AudioSource BoyaSıcratma;

    public GameObject baslangıcefekt;
    public AdManager adManager;
    public GameObject YeniGameOverMenü;
    public GameObject GameOverButonlar;
    public GameObject MarketMenüsü;

    public GameObject ArtMarket;
    public TextMeshProUGUI[] EserAdetText;
    public GameObject[] Eserler;
    



    public Slider resim;
    
    public static float kutuvurmasayisi = 0;
    public GameObject[] kaliteliresimler;
    
    public GameObject[] kötüresimler;
   
    
    public GameObject arkaplan;
    public Material[] materials;

    
    Renderer rend;
    private int canvas;
    //public int skor;
    public TextMeshProUGUI Highscore; 
    Vector3 pozisyon=new Vector3(0,0,0);
    private int ihtimalsınırı;
    private int kaliteihtimali;
    public static GameManager instance;


    [Header(" TEXTLER ")]
    public GameObject tuvalsimgesi;
    public TextMeshProUGUI PointText;
    public TextMeshProUGUI SkoreText;
    public TextMeshProUGUI HighSkoreText;
    public TextMeshProUGUI BoyaSayısıText;
    public TextMeshProUGUI MoneyText;
    public int Score;
    private Camera cam;

    

    public static int say;
    public static bool OyunBitti;

    public BoxCollider col; //çöp objesi, düşen kutuların kontrolü sağlanacak

    public GameObject SallancakSlider;
    public float duration;
    public float strength;
    public int vibrato;
    public float randomness;

    public bool sallandı = false;

    public GameObject EserÖncesiBoya;
    public TextMeshPro KeepItUpyazı;
    public TextMeshPro ItWasGreatyazı;

    public  int cubuk1adt;
    public  int cubuk2adt;
    public  int cubuk3adt;
    public  int cubuk4adt;

    public  int nadir1adt;
    public  int nadir2adt;

    public int[] Eseradtlist = new int[6];

    
    

    public int money;
    public int BoyaSayısı;
    
    float currentVelo;

    public GameObject AdObject;
    
    public Text premcanvasbutontexts;
    public GameObject premcanvasbutonobj;

    public GameObject afterbuycanv;

    public BrushEffect brushEffect;
    public bool boyavurdun;
    public static int renkdegis;

    
    
    private void Awake()
    {
        EserAdtPf();
        
        money = PlayerPrefs.GetInt("para");
        BoyaSayısı = PlayerPrefs.GetInt("boya");
        if (BoyaSayısı <= 0)
            PlayerPrefs.SetInt("boya", 25);

    }


    void Start()
    {
        
        baslangıcefekt.GetComponent<Image>().DOFade(0, .5f);
        BoyaSayısı = PlayerPrefs.GetInt("boya");
        BoyaSayısıText.SetText(BoyaSayısı.ToString());
        ArtCountTextUpdate();
        ArtMarketCheck();
        Score = 0;
        kutuvurmasayisi = resim.value;
        OyunBitti = false;
        say = 0;
        cam = Camera.main;
        instance = this;
        Highscore.SetText(PlayerPrefs.GetInt("score").ToString());
        rend = arkaplan.GetComponent<Renderer>();
        MarketCheck();
        // InvokeRepeating("SliderAzalt",0, 1);
        ScoreUpdate();

    }


    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            brushEffect.CreateLine();
        }
        
       
        RayCastKontrol();
        BoyaSayısıText.SetText(BoyaSayısı.ToString());
        resim.value = kutuvurmasayisi;
        if (resim.value>=5&&!sallandı) // resimin ne zaman ortaya çıkacağı
        {
          int ilkrandomsayı=Random.Range(0,ihtimalsınırı);
            Debug.Log(ilkrandomsayı);
          if (ilkrandomsayı>=0&&ilkrandomsayı<=90) // burada ihtimal ile iyi yada kötü resim yaptığın kararlaştırılıyor
          {
                KotuEserGetır();
                
          }

          else
          {
                GuzelEserGetır();
          }

         
        }
        StartCoroutine(SliderAzaltv2());
        GameOverControl();
      
    }

    void KotuEserGetır()
    {
        int randomresimseç = Random.Range(0, 4);
        ShowArt(kötüresimler[randomresimseç], KeepItUpyazı,"+5",5,KötüresimMüzik);
        
        switch (randomresimseç)
        {
            case 0:
                Eseradtlist[randomresimseç] += 1;
                cubuk1adt += 1;
                if (cubuk1adt >= 1)
                {
                    Eserler[0].SetActive(true);

                }
                Debug.Log("CUBUK1 ADETİ " + cubuk1adt);
                break;
            case 1:
                Eseradtlist[randomresimseç] += 1;
                cubuk2adt += 1;
                if (cubuk2adt >= 1)
                {
                    Eserler[1].SetActive(true);

                }
                Debug.Log("CUBUK2 ADETİ  " + cubuk2adt);
                break;
            case 2:
                Eseradtlist[randomresimseç] += 1;
                cubuk3adt += 1;
                if (cubuk3adt >= 1)
                {
                    Eserler[2].SetActive(true);

                }
                Debug.Log("CUBUK3 ADETİ " + cubuk3adt);
                break;
            case 3:
                Eseradtlist[randomresimseç] += 1;
                cubuk4adt += 1;
                if (cubuk4adt >= 1)
                {
                    Eserler[3].SetActive(true);

                }
                Debug.Log("CUBUK4 ADETİ " + cubuk4adt);
                break;


            default:
                Debug.Log("DEFAULT CALISTI");
                break;
        }

        ArtCountTextUpdate();
        SetArtPlayerFrefs();


    }

    void GuzelEserGetır()
    {
        int kaliteliresimsec = Random.Range(0, 2);
        ShowArt(kaliteliresimler[kaliteliresimsec], ItWasGreatyazı,"+50",50,İyiResimMüzik);
        //resimgöster(kaliteliresimler[kaliteliresimsec],efekt);
       
        switch (kaliteliresimsec)
        {
            case 0:
                Eseradtlist[4] += 1;
                nadir1adt += 1;
                Debug.Log("NADİR1 ADETİ  " + nadir1adt);
                if (nadir1adt >= 1)
                {
                    Eserler[4].SetActive(true);

                }
                break;
            case 1:
                Eseradtlist[5] += 1;
                nadir2adt += 1;
                Debug.Log("NADİR2 ADETİ " + nadir2adt);
                if (nadir2adt >= 1)
                {
                    Eserler[5].SetActive(true);

                }
                break;

            default:
                break;
        }

        ArtCountTextUpdate();
        SetArtPlayerFrefs();
    }


   

   
    void ShowArt(GameObject eser,TextMeshPro yazı,string skoreText,int Point,AudioSource müzik)
    {
        Score += Point;
        sallandı = true;
        spawner.SpawnEt = false;
        GameObject[] tempkutular = GameObject.FindGameObjectsWithTag("kutu"); // oyun bittiğinde sahnedeki kutuları topluyor içine

        ScoreUpdate();
        
        if (tempkutular != null)
        {
            foreach (var item in tempkutular)
            {
                item.GetComponent<BoxCollider>().enabled = false;
                item.GetComponent<Renderer>().enabled = false ;
                
            }

        }

        OnReportLeaderboardScore();




        SallancakSlider.transform.DOShakeScale(duration, strength, vibrato, randomness).OnComplete(() =>
        {
            BoyaSıcratma.Play();
            cam.DOShakePosition(1, 1); //slider sallanması bittiğinde ekrana boyalar fırlatılıyormuşçasına ekran titriyor
            kutuvurmasayisi = 0;
            //buraya yandaki bar dolduğunda bar biraz sallansın ve bittikten sonra sıfırlanıp aşağıdaki kodlar çalışsın
            PointText.SetText(skoreText);
            PointText.DOFade(1, .5f);
            
            GameObject esertemp = Instantiate(eser, eser.transform.position, Quaternion.identity);

            esertemp.GetComponent<SpriteRenderer>().DOFade(1, 2).OnComplete(() =>
            {
                 esertemp.transform.DORotate(new Vector3(0, 0, 90), .1f).SetLoops(-1, LoopType.Incremental);
                 esertemp.transform.DOScale(new Vector3(0, 0, 0), 1f);
                 esertemp.transform.DOMove(tuvalsimgesi.transform.position, .7f).OnComplete(() =>
                 {

                     TextMeshPro yazıtmp = Instantiate(yazı, yazı.transform.position, Quaternion.identity);//bu kodu setactive ile değiştirip
                     yazıtmp.transform.DOScale(new Vector3(1, 1, 0), .15f);
                     müzik.Play();
                     SkoreText.SetText("Ability To Draw  " + Score.ToString());
                     tuvalsimgesi.transform.DOShakeScale(1, 1, 7, 45).OnComplete(() => {

                         PointText.DOFade(0, .3f);
                         yazıtmp.DOFade(0, .5f).OnComplete(() => Destroy(yazıtmp));
                     });

                     sallandı = false;
                     spawner.SpawnEt = true;
                     Destroy(esertemp);

                 });

             });//yazıyı burada yok etmiştik

            GameObject boyatemp = Instantiate(EserÖncesiBoya, new Vector3(0, 0, 0), Quaternion.identity);

            StartCoroutine(eseröncesiboya(boyatemp));
            //slider bittiğinde splash müzik çalmalı,bu ise yaz çıktığı an çalmalı
            /*boyatemp.GetComponent<SpriteRenderer>().DOFade(0,1).OnComplete(() =>// boya kaybolduğu vakit eserin boyu küçülerek tuvale doğru gidiyor
            {
                Destroy(boyatemp);
                
            });*/
        });




    }
   


    
    IEnumerator eseröncesiboya(GameObject boya)
    {
        yield return new WaitForSeconds(1);

        boya.GetComponent<SpriteRenderer>().DOFade(0, 1).OnComplete(() =>// boya kaybolduğu vakit eserin boyu küçülerek tuvale doğru gidiyor
        {
            Destroy(boya);

        });
    }


     public  void SellFonk(int miktar)// BURASI ŞU ANDA İŞLEVSİZ
     {

        money+=miktar;
        MoneyText.SetText(money.ToString()+"  $");
        PlayerPrefs.SetInt("para", money);
        
     }

      public  void ScoreUpdate()
       {

           if (PlayerPrefs.GetInt("score")<Score)
           {
                 PlayerPrefs.SetInt("score",Score);//bunun altına LeaderTablosuna skorunu güncelleyeceğiz;
           }
       }

    private async void OnReportLeaderboardScore()
    {
        var leaderboards = await GKLeaderboard.LoadLeaderboards();
        var leaderboard = leaderboards.First(l => l.BaseLeaderboardId == "davut177");

        await leaderboard.SubmitScore(Score, 0, GKLocalPlayer.Local);

        

        var scores = await leaderboard.LoadEntries(GKLeaderboard.PlayerScope.Global, GKLeaderboard.TimeScope.AllTime, 0, 100);

        Debug.LogError($"my score: {scores.LocalPlayerEntry.Score}");

        foreach (var score in scores.Entries)
        {
            Debug.LogError($"score: {score.Score} by {score.Player.DisplayName}");
        }
    }




    void RayCastKontrol() 
    {
        

        if (Input.GetButton("Fire1"))//touch ile değiştirmelisin
        {
            brushEffect.CızgıCek();

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit vurmak, 100))
            {
                Iclickable clickable = vurmak.collider.GetComponent<Iclickable>();

                if (vurmak.collider.name == ("kırmızı(Clone)"))
                {
                    renkdegis = 1;
                }

                if (vurmak.collider.name == ("mavi(Clone)"))
                {
                    renkdegis = 2;
                }

                if (vurmak.collider.name == ("siyah(Clone)"))
                {
                    renkdegis = 3;
                }
                if (vurmak.collider.name == ("mor(Clone)"))
                {
                    renkdegis = 4;
                }
                if (vurmak.collider.name == ("yeşil(Clone)"))
                {
                    renkdegis = 5;
                }
                if (vurmak.collider.name == ("kahverengi(Clone)"))
                {
                    renkdegis = 6;
                }


                if (clickable != null)
                {
                    brushEffect.CreateLine();
                    clickable.click();
                    resim.value = kutuvurmasayisi;

                   
                }

                

                if (vurmak.collider.tag == ("domates"))
                {
                    vurmak.collider.GetComponent<Domatescript>().domatevurdun();
                }


            }
            boyavurdun = false;
        }
        
    }

    

    
    

    public void GameOverControl()// bu fonksiyonu update içinde çalıştırıyoruz ki sürekli oyunun bitip bitmediği kontrol edilsin.
    {
        if(say==3||OyunBitti||BoyaSayısı<=0) //oyunun bittiğini burada kontrol ediyoruz
        {
            OyunBitti = true;
            spawner.SpawnEt = false;
            MoneyText.SetText(money.ToString() + " $");
            ReklamGetir();
            MoneyText.DOFade(1, .4f);
            GameObject[] tempkutular = GameObject.FindGameObjectsWithTag("kutu"); // oyun bittiğinde sahnedeki kutuları topluyor içine
            
            if (tempkutular != null)
            {
                foreach (var item in tempkutular)
                {
                    Destroy(item);
                }

            }
            
        }
    }

    #region MENU KODLARI

    public void LostArtMarket()
    {
        ArtMarket.transform.DOLocalMove(new Vector3(0, 6000, 0), .3f);
        GameOverMenu();
        GameOverButonlar.SetActive(true);
    }

    public void GetArtMarket()
    {
        GameOverButonlar.SetActive(false);
        ArtMarket.transform.DOLocalMove(new Vector3(0, 0, 0), .3f);

    }

    public void MarketKapaMenüAc()
    {
        MarketMenüsü.transform.DOLocalMove(new Vector3(-2500, 0, 0), .3f);
        GameOverButonlar.SetActive(true);
        
    }

    public void GetMarket()
    {
        GameOverButonlar.SetActive(false);
        MarketMenüsü.transform.DOLocalMove(new Vector3(0, 0, 0), .3f);

    }

    public void GameOverMenu()
    {
        GameOverButonlar.transform.DOLocalMove(new Vector3(0, 0, 0), .4f);
        ArtMarketCheck();
        ArtCountTextUpdate();
        
    }

    public void ReklamGetir()
    {
        YeniGameOverMenü.GetComponent<Image>().DOFade(1, .6f).OnComplete(() =>
        {
            
            AdObject.transform.DOLocalMove(new Vector3(0, 0, 0), .4f);
        });
        

    }

    public void GetMona()
    {
        buttonsound.Play();
        //burada önce reklam görecek devamında mona tablosunu elde edicel;
        adManager.ShowRewardedAd();
        nadir1adt += 1;
        PlayerPrefs.SetInt("nadir1adt", nadir1adt);
        ReklamGotur();
    }

    public void ReklamGotur()
    {
        buttonsound.Play();
        AdObject.SetActive(false);
        GameOverMenu();
    }

    public void ArtMarketCheck()
    {
        EserlistUpdate();

        for (int i = 0; i < Eseradtlist.Length; i++)
        {
            if (Eseradtlist[i] >= 1)
            {
                Eserler[i].SetActive(true);
            }
        }
    }

    #endregion

    #region KONTROL KODLARI

    public void MarketCheck()// markette bulunan tuvallerin satın alınma durumunu kontrol ediyor,market kapandıktan sonra veya restart yapıldıktan sonra çalışmalı
    {
        canvas = PlayerPrefs.GetInt("marketsatınaldı"); //burada hiyerarşide bulunan arka plan objesinin materyali değiştirilerek
        if (canvas != 2 && canvas != 3 && canvas != 4 && canvas != 5||canvas==1)                                 //tuval değiştirmiş oluyoruz, şimdi canvasta bir panalin imagini değiştirerek aynı işlemi yapacağız.
        {
            rend.sharedMaterial = materials[0]; // canvas denenem başarısız oldu. Boya kutuları artık görünmüyor,eski yönteme dönmeden önce biraz araştırma yapmalıyım
            ihtimalsınırı = 100;
        }
        else if (canvas == 2)
        {
            rend.sharedMaterial = materials[1];
            ihtimalsınırı = 105;

        }
        else if (canvas == 3)
        {
            rend.sharedMaterial = materials[2];
            ihtimalsınırı = 110;
        }
        else if (canvas == 4)
        {
            rend.sharedMaterial = materials[3];
            ihtimalsınırı = 115;
        }
        else if (canvas == 5)
        {
            rend.sharedMaterial = materials[4];
            ihtimalsınırı = 125;

        }
    }

    #endregion

    #region SET ETME KODLARI

    public void EserlistUpdate()
    {
        Eseradtlist[0] = cubuk1adt;
        Eseradtlist[1] = cubuk2adt;
        Eseradtlist[2] = cubuk3adt;
        Eseradtlist[3] = cubuk4adt;
        Eseradtlist[4] = nadir1adt;
        Eseradtlist[5] = nadir2adt;

    }
    public void EserAdtPf()// bu startta başlamalı
    {
        cubuk1adt = PlayerPrefs.GetInt("cubuk1adt");
        cubuk2adt = PlayerPrefs.GetInt("cubuk2adt");
        cubuk3adt = PlayerPrefs.GetInt("cubuk3adt");
        cubuk4adt = PlayerPrefs.GetInt("cubuk4adt");

        nadir1adt = PlayerPrefs.GetInt("nadir1adt");
        nadir2adt = PlayerPrefs.GetInt("nadir2adt");
    }

    

    #endregion





    public void Buy(int moneyy) // Canvar satış butonunda bunu da çağırcaksın
    {
        money -= moneyy;
        MoneyText.SetText(money.ToString() + "$");
        PlayerPrefs.SetInt("para", money);
    }

    public void SetArtPlayerFrefs()  //cubuk ve nadir değişkenini pf'ye set ediyor/bu her resim yapıldığında çalışmalı 
    {
        PlayerPrefs.SetInt("cubuk1adt", cubuk1adt);
        PlayerPrefs.SetInt("cubuk2adt", cubuk2adt);
        PlayerPrefs.SetInt("cubuk3adt", cubuk3adt);
        PlayerPrefs.SetInt("cubuk4adt", cubuk4adt);

        PlayerPrefs.SetInt("nadir1adt", nadir1adt);
        PlayerPrefs.SetInt("nadir2adt", nadir2adt);
    }

   public void ArtCountTextUpdate() // cubuk ve nadir değişkenini kullanarak var olan eser adet textini set ediyor;
    {
        EserAdetText[0].SetText(cubuk1adt + " Pieces");
        EserAdetText[1].SetText(cubuk2adt + " Pieces");
        EserAdetText[2].SetText(cubuk3adt + " Pieces");
        EserAdetText[3].SetText(cubuk4adt + " Pieces");
        EserAdetText[4].SetText(nadir1adt + " Pieces");
        EserAdetText[5].SetText(nadir2adt + " Pieces");
   }

   

    private IEnumerator SliderAzaltv2()
    {
        if (sallandı)
        {
            yield return new WaitForSeconds(1.5f);
            kutuvurmasayisi = Mathf.SmoothDamp(kutuvurmasayisi, 0, ref currentVelo, 400 * Time.deltaTime);
        }
        else
            kutuvurmasayisi = Mathf.SmoothDamp(kutuvurmasayisi, 0, ref currentVelo, 400 * Time.deltaTime);


    }

    
}
