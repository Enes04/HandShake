using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GiftType { candy , gum , chocolate };
public class GameManager : MonoBehaviour
{
    public ParticleSystem finishParticle;
    public GameObject winP;
    public GameObject loseP;
    public GameObject handUi;
    public GameObject hands;

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
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
}
