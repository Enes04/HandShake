using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    public Collider[] enemyColliders;
    public GiftType mygiftType;
    public Canvas enemycanvas;
    public ParticleSystem sadParticle;
    public ParticleSystem happyParticle;
    Player pl;
    public int enemyDollar;
    public TextMeshProUGUI enemyDollarText;

    void Start()
    {
        pl = FindObjectOfType<Player>();
        enemycanvas = GetComponentInChildren<Canvas>();
        enemycanvas.worldCamera = Camera.main;
        enemyDollarText.text = "$" + enemyDollar.ToString();
        EnemyStart();
    }
    public void EnemyStart()
    {
        if(mygiftType == GiftType.candy)
        {
            enemycanvas.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        }
        else if (mygiftType == GiftType.gum)
        {
            enemycanvas.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        }
        else if (mygiftType == GiftType.chocolate)
        {
            enemycanvas.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        }
    }
    public void enemyColliderOff()
    {
        EnemyCollider currentCollider = GetComponentInChildren<EnemyCollider>();
        for (int i = 0; i < 2; i++)
        {
            currentCollider.colliders[i].gameObject.SetActive(false);
        }
    }
    void Update()
    {
        var lookrot = pl.transform.position - transform.position;
        lookrot.y = 0;
        var rotation = Quaternion.LookRotation(-1*lookrot);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
    }

 
}
