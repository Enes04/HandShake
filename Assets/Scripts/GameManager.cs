using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        plMovement = FindObjectOfType<PlayerMovement>();
        plMovement.speed = 0;
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 0);
        }
        levels[PlayerPrefs.GetInt("Level") % 5].gameObject.SetActive(true);
        
    }
    public void startGame()
    {
        plMovement.speed = 2;
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
}
