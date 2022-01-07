using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Collider[] enemyColliders;
    public GiftType mygiftType;
    public Canvas enemycanvas;
    Player pl;
    void Start()
    {
        pl = FindObjectOfType<Player>();
        enemycanvas = GetComponentInChildren<Canvas>();
        enemycanvas.worldCamera = Camera.main;
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
        for (int i = 0; i < enemyColliders.Length; i++)
        {
            enemyColliders[i].enabled = false;
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
