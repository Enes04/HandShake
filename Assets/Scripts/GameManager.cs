using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using ElephantSDK;
//using GameAnalyticsSDK;
public enum GiftType { candy, gum, chocolate };
public class GameManager : MonoBehaviour
{
    public ParticleSystem finishParticle;
    public GameObject winP;
    public GameObject loseP;
    public GameObject handUi;
    public GameObject hands;
    public GameObject canBar;
    public GameObject playerfinishPos;
    public GameObject[] levels;
    PlayerMovement plMovement;
    public GameObject tutorials;
    public GameObject tuto1;
    public GameObject tuto2;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        plMovement = FindObjectOfType<PlayerMovement>();
        plMovement.speed = 0;
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 0);
            tutorials.SetActive(true);
        }
        levels[PlayerPrefs.GetInt("Level") % 5].gameObject.SetActive(true);
#if UNITY_IOS
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (ElephantIOS.getConsentStatus() == "Authorized")
            {
                GameAnalytics.Initialize();
            }
        }
#endif
    }
    public void startGame()
    {
        plMovement.speed = 1.5f;
        plMovement.shakeCam();
    }
    public void GameFail()
    {
        loseP.SetActive(true);
    }
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void winCon()
    {
#if UNITY_IOS
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                if (ElephantIOS.getConsentStatus() == "Authorized")
                {
                    Elephant.LevelCompleted(PlayerPrefs.GetInt("Level"));
                    GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, PlayerPrefs.GetInt("Level").ToString());
                }
            }
#endif
    }
    public void failCon()
    {
#if UNITY_IOS
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (ElephantIOS.getConsentStatus() == "Authorized")
            {
                Elephant.LevelFailed(PlayerPrefs.GetInt("Level"));
                GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, PlayerPrefs.GetInt("Level").ToString());
            }
        }
#endif
    }
    void Update()
    {
        FollowTheHand();
    }
    public void FollowTheHand()
    {
        Vector3 goldPos = Camera.main.WorldToScreenPoint(hands.transform.position);
        handUi.transform.position = goldPos;
    }
    public void NextLevel()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        SceneManager.LoadSceneAsync("MainGame");
    }
    public void TryLevel()
    {
        SceneManager.LoadSceneAsync("MainGame");
    }
    public void CloseTutorial()
    {
        Time.timeScale = 1;
    }
}
