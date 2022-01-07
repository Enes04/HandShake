using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAction : MonoBehaviour
{
    PlayerMovement plMovement;
    PlayerDrag plDrag;
    Player pl;

    private void Start()
    {
        plMovement = FindObjectOfType<PlayerMovement>();
        plDrag = FindObjectOfType<PlayerDrag>();
        pl = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hand"))
        {
            if (other.GetComponentInParent<Enemy>().mygiftType == pl.mygifttype)
            {
                TruePeople(other.gameObject);
            }
            else
            {
                WrongPeople(other.gameObject);
            }
        }
        if (other.CompareTag("Body"))
        {
            WrongPeople(other.gameObject);
        }
    }

    public void WrongPeople(GameObject enemy)
    {
        enemy.GetComponentInParent<Enemy>().enemyColliderOff();
        plMovement.isGo = false;
        plDrag._sensitivity = 0;
        plMovement.transformKill();
        pl.GetPunch();
    }
    public void TruePeople(GameObject enemy)
    {
        enemy.GetComponentInParent<Enemy>().enemyColliderOff();
        plMovement.isGo = false;
        plDrag._sensitivity = 0;
        plMovement.transformKill();
    }
}
