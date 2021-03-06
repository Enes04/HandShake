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
    int failCount;
    Canvas canvasMain;
    int coincount;

    private void Start()
    {
        plMovement = FindObjectOfType<PlayerMovement>();
        plDrag = FindObjectOfType<PlayerDrag>();
        pl = FindObjectOfType<Player>();
        fp = FindObjectOfType<FinishPeoples>();
        canvasMain = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            VibrationManager.Instance.Pop();
            if (other.GetComponentInParent<Enemy>().enemyDollar >= 1)
            {
                TruePeople(other.gameObject);
            }
            else
            {
                GameManager.instance.canBar.transform.GetChild(failCount).gameObject.SetActive(false);
                homeless(other.gameObject);
            }
        }
        if (other.CompareTag("Body"))
        {
            VibrationManager.Instance.Pop();
            GameManager.instance.canBar.transform.GetChild(failCount).gameObject.SetActive(false);
            //pl.shakeCam();
            WrongPeople(other.gameObject);

        }
        if (other.CompareTag("Finish"))
        {
            VibrationManager.Instance.Pop();
            FinishGames(other.gameObject.transform.parent.GetChild(1).gameObject);
            plMovement.transformKill();
        }
        if (other.CompareTag("tuto1"))
        {
            GameManager.instance.tuto1.SetActive(true);
            Time.timeScale = 0;
        }
        if (other.CompareTag("tuto2"))
        {
            GameManager.instance.tuto2.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void FinishGames(GameObject finisPos)
    {
        playerStop();
        GameManager.instance.winCon();
        pl.anim.SetTrigger("dance");
        pl.anim.applyRootMotion = true;
        pl.anim.transform.DOMove(GameManager.instance.playerfinishPos.transform.position, 1f);
        pl.anim.transform.localScale = new Vector3(1, 1, 1);
        Camera.main.transform.parent = null;
        GameObject currentposCamera = GameObject.FindGameObjectWithTag("camerafinish");
        GameManager.instance.handUi.SetActive(false);
        GameObject.FindObjectOfType<HandScript>().GetComponent<MeshRenderer>().enabled = false;
        Camera.main.transform.position = currentposCamera.transform.position;
        Camera.main.transform.rotation = Quaternion.Euler(15, 180, 0);
        GameManager.instance.winP.gameObject.SetActive(true);
        //pl.transform.DORotateQuaternion(Quaternion.Euler(0,180,0),1f);
        fp.PeopleLine();
    }
    IEnumerator coinGoes()
    {
        yield return new WaitForSeconds(0.06f);
        coinGo();
    }
    public void coinGo()
    {
        if(coincount<5)
        {
            GameObject current = Instantiate(Resources.Load<GameObject>("GoldImage"), canvasMain.transform);
            Vector3 goldpos = Camera.main.WorldToScreenPoint(this.transform.position);
            current.transform.position = goldpos;
            current.transform.DOLocalMove(canvasMain.transform.GetChild(0).transform.localPosition, 1f).OnComplete(() =>
            {
                Destroy(current);
            });
            coincount++;
            StartCoroutine(coinGoes());
        }else
        {
            coincount = 0;
        }
      
    }
    public void homeless(GameObject enemy)
    {
        if (enemy.GetComponentInParent<Enemy>().myenemyType == enemyType.gun)
        {
            enemy.GetComponentInChildren<EnemyHandScript>().silah.SetActive(true);
        }
        if (enemy.GetComponentInParent<Enemy>().myenemyType == enemyType.knife)
        {
            enemy.GetComponentInChildren<EnemyHandScript>().bicak.SetActive(true);
            enemy.GetComponentInParent<Animator>().SetTrigger("levye");
           
        }
        if (enemy.GetComponentInParent<Enemy>().myenemyType == enemyType.levye)
        {
            enemy.GetComponentInChildren<EnemyHandScript>().levye.SetActive(true);
            enemy.GetComponentInParent<Animator>().SetTrigger("levye");
            
        }

        enemy.GetComponentInParent<Enemy>().enemyColliderOff();
        enemy.GetComponentInParent<Enemy>().enemyDollarText.text = "$" + (pl.currentDollar + enemy.GetComponentInParent<Enemy>().enemyDollar).ToString();
        enemy.GetComponentInParent<Enemy>().happyParticle.Play();
        pl.playerDollarCount = pl.playerDollarCount - pl.currentDollar;
        pl.playerText.text = pl.playerDollarCount.ToString();
        if (pl.playerDollarCount <= 0 || failCount >= 2)
        {
            playerStop();
            plMovement.transformKill();
            pl.FailCondition();
        }
        else
        {
            playerStop();
            Invoke("ShakeCams", 0.75f);
            Invoke("GoPlayerReturn", 1f);
        }
        failCount++;
    }
    public void ShakeCams()
    {
        pl.shakeCam();
    }
    public void WrongPeople(GameObject enemy)
    {
        enemy.GetComponentInParent<Animator>().SetTrigger("hit");
        enemy.GetComponentInParent<Enemy>().enemyColliderOff();
        enemy.GetComponentInParent<Enemy>().enemyDollarText.text = "$" + (pl.currentDollar + enemy.GetComponentInParent<Enemy>().enemyDollar).ToString();
        enemy.GetComponentInParent<Enemy>().happyParticle.Play();
        pl.playerDollarCount = pl.playerDollarCount - pl.currentDollar;
        pl.playerText.text = pl.playerDollarCount.ToString();

        if (pl.playerDollarCount <= 0 || failCount >= 2)
        {
            playerStop();
            plMovement.transformKill();
            pl.FailCondition();
        }
        else
        {
            playerStop();
            Invoke("GoPlayerReturn", 1f);
        }
        failCount++;
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
        enemy.GetComponentInParent<Enemy>().enemyDollarText.text = "$" + 0.ToString();
        enemy.GetComponentInParent<Enemy>().enemyColliderOff();
        enemy.GetComponentInParent<Enemy>().sadParticle.Play();
        playerStop();
        plMovement.transformKill();
        coinGo();

        Invoke("GoPlayerReturn", 1f);
    }

    public void playerStop()
    {
        plMovement.isGo = false;
        plDrag._sensitivity = 0;
    }
    public void GoPlayerReturn()
    {
        pl.anim.SetTrigger("openhand");
        plDrag._sensitivity = 0.03f;
        plMovement.isGo = true;
        pl.PlayerObjChoose();
        plMovement.shakeCam();
        transform.parent.GetComponentInChildren<HandScript>().hand.SetActive(false);
    }
}
