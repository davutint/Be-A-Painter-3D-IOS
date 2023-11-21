using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Apple.GameKit;
using Apple.GameKit.Multiplayer;
using System;
using System.Threading.Tasks;
using Apple.GameKit.Leaderboards;
using System.Linq;
using UnityEngine.SocialPlatforms.Impl;

public class AnamenuManager : MonoBehaviour
{
    /*public GameObject LiderTablosuPanel;
    [SerializeField]
    private string[] badWords;
    string myString;*/

    /*public TMP_InputField PlayerNameKayit;

    public GameObject oyuncuKayıtBolumu;
    public PlayerManager playerManager;

    public static bool kayit;*/


    public GameObject StartButonuobj;


    public AudioSource startsound;
    public AudioSource buttonsound;
    public GameObject SahneDegisimPanel;

    public menuadmanager Menuadmanager;
    // Start is called before the first frame update
    private async void Awake()
    {
        await Login();
    }

    public async Task Login()
    {
        if (!GKLocalPlayer.Local.IsAuthenticated)
        {
            // Perform the authentication.
            var player = await GKLocalPlayer.Authenticate();
            Debug.Log($"GameKit Authentication: player {player}");

            // Grab the display name.
            var localPlayer = GKLocalPlayer.Local;
            Debug.Log($"Local Player: {localPlayer.DisplayName}");

            // Fetch the items.
            //var fetchItemsResponse = await GKLocalPlayer.Local.FetchItems();

        }
    }

    private void Start()
    {


        GKAccessPoint.Shared.Location = GKAccessPoint.GKAccessPointLocation.TopLeading;
        GKAccessPoint.Shared.ShowHighlights = false;
        ShowAccesPoint();


    }






    public void ShowAccesPoint()
    {
        GKAccessPoint.Shared.IsActive = !GKAccessPoint.Shared.IsActive;


    }

    public async void OnShowLeaderboard()
    {
        try
        {

            var leaderboards = await GKLeaderboard.LoadLeaderboards();
            var leaderboard = leaderboards.First(l => l.BaseLeaderboardId == "davut177");
            // Wait for player to close the dialog...
            var gameCenter = GKGameCenterViewController.Init(GKGameCenterViewController.GKGameCenterViewControllerState.Leaderboards);
            await gameCenter.Present();


            var scores = await leaderboard.LoadEntries(GKLeaderboard.PlayerScope.Global, GKLeaderboard.TimeScope.AllTime, 0, 100);

            Debug.LogError($"my score: {scores.LocalPlayerEntry.Score}");

            foreach (var score in scores.Entries)
            {
                Debug.LogError($"score: {score.Score} by {score.Player.DisplayName}");
            }

        }
        catch (Exception exception)
        {
            Debug.LogError(exception);
        }
    }



    public void exit()
    {
        Application.Quit();   
    }

   /* public void LiderTablosuGetir() //bok gibi bunu adam et
    {
       LiderTablosuPanel.transform.DOLocalMove(new Vector3(0, 0, 0), .3f);
        buttonsound.Play();
  
    }

    public void LeaderBoardBack()
    {
        buttonsound.Play();
        LiderTablosuPanel.transform.DOLocalMove(new Vector3(2000, 0, 0), .3f);
    }

    public void ChangeString(string stringIn)
    {
        myString = stringIn;
        BadWordParser();
    }


    void BadWordParser()
    {
        for (int i = 0; i < badWords.Length; i++)
        {
            if (myString.ToLower().Contains(badWords[i]))
            {
                for (int j = 0; j < myString.Length; j++)
                {
                    if (myString.ToLower()[j] == badWords[i][0])
                    {
                        string temp = myString.Substring(j, badWords[i].Length);
                        if (temp.ToLower() == badWords[i])
                        {
                            myString = myString.Remove(j, badWords[i].Length);

                            if (myString != null)
                            {
                                
                                 PlayerNameKayit.text = myString.ToString();
                                
                            }
                            else
                            {
                                
                                PlayerNameKayit.text = "";
                            }
                            return;
                        }
                    }
                }
            }


            
        }
       
        
        
    }

    public void login()
    {
        string playerıd = PlayerNameKayit.text.ToString();
        if (playerıd != "")
        {
            buttonsound.Play();
            PlayerPrefs.SetString("PlayerName", playerıd);
            playerManager.SetPlayerName(playerıd);
            oyuncuKayıtBolumu.SetActive(false);
            PlayerPrefs.SetInt("kayıt", 2);
            Debug.Log(playerıd+" isim bu");
        }
        
    }
    public void oyuncukayitEkraniKontrol()
    {
        int temp = PlayerPrefs.GetInt("kayıt");     
        if (temp != 2)
        {
            oyuncuKayıtBolumu.SetActive(true);
        }

    }*/

    public void StartGame()
    {
        startsound.Play();
        StartButonuobj.transform.DOShakeScale(.5f, 1, 3, 3).OnComplete(() =>
        {
            
            SahneDegisimPanel.GetComponent<Image>().DOFade(1, .5f).OnComplete(() =>
            {
                SceneManager.LoadScene(1);
            });
        });

        if (GKAccessPoint.Shared.IsActive==true)
        {
            GKAccessPoint.Shared.IsActive = false;
        }

        Menuadmanager.destroyBanner();
        
        
    }

    /*public void ChangeName()
    {
        oyuncuKayıtBolumu.SetActive(true);
        buttonsound.Play();
        LeaderBoardBack();
    }*/


}
