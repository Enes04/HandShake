using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    public GiftType mygiftType;
    public Canvas enemycanvas;

    void Start()
    {
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
    void Update()
    {
        
    }
}
