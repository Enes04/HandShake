using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAction : MonoBehaviour
{
    PlayerMovement plMovement;
    PlayerDrag plDrag;
    Player pl;
    FinishPeoples fp;
    private void Start()
    {
        plMovement = FindObjectOfType<PlayerMovement>();
        plDrag = FindObjectOfType<PlayerDrag>();
        pl = FindObjectOfType<Player>();
        fp = FindObjectOfType<FinishPeoples>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            if (other.GetComponentInParent<Enemy>().enemyDollar >= 1)
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
        if(other.CompareTag("Finish"))
        {
            FinishGames(other.gameObject.transform.parent.GetChild(1).gameObject);
        }
    }
    public void FinishGames(GameObject finisPos)
    {
        playerStop();
        //pl.transform.transform.DOMoveZ(finisPos.transform.position.z , 2f);
        pl.transform.DORotateQuaternion(Quaternion.Euler(0,180,0),1f);
        fp.PeopleLine();
    }
    public void WrongPeople(GameObject enemy)
    {
        enemy.GetComponentInParent<Enemy>().enemyColliderOff();
        enemy.GetComponentInParent<Enemy>().enemyDollarText.text = "$"+(pl.currentDollar + enemy.GetComponentInParent<Enemy>().enemyDollar).ToString();
        enemy.GetComponentInParent<Enemy>().happyParticle.Play();
        pl.playerDollarCount = pl.playerDollarCount - pl.currentDollar;
        pl.playerText.text = pl.playerDollarCount.ToString();
      
        if (pl.playerDollarCount <=0)
        {
            playerStop();
            pl.FallCam();
        }
        else
        {
            playerStop();
            Invoke("GoPlayerReturn", 1f);
        }
        //pl.GetPunch();
    }
    public void TruePeople(GameObject enemy)
    {
        int rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0:
                enemy.GetComponentInParent<Animator>().SetTrigger("dontwant");
                break;
            case 1:
                enemy.GetComponentInParent<Animator>().SetTrigger("dontwant1");
                break;
            case 2:
                enemy.GetComponentInParent<Animator>().SetTrigger("dontwant2");
                break;
            default:
                break;
        }
        fp.addPeople(enemy);
        pl.playerDollarCount = pl.playerDollarCount + enemy.GetComponentInParent<Enemy>().enemyDollar;
        pl.playerText.text = pl.playerDollarCount.ToString();
        enemy.GetComponentInParent<Enemy>().enemyDollarText.text ="$"+0.ToString();
        enemy.GetComponentInParent<Enemy>().enemyColliderOff();
        enemy.GetComponentInParent<Enemy>().sadParticle.Play();
        playerStop();
        Invoke("GoPlayerReturn", 1f);
    }

    public void playerStop()
    {
        plMovement.isGo = false;
        plDrag._sensitivity = 0;
        plMovement.transformKill();
    }
    public void GoPlayerReturn()
    {
        pl.anim.SetTrigger("openhand");
        plDrag._sensitivity = 0.2f;
        plMovement.isGo = true;
        pl.PlayerObjChoose();
        plMovement.shakeCam();
        transform.parent.GetComponentInChildren<HandScript>().hand.SetActive(false);
    }
}
