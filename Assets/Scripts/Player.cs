using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Player : MonoBehaviour
{
    public int playerDollarCount;
    public GameObject objeler;
    PlayerMovement plMovement;
    Camera mainCam;
    PlayerDrag plDrag;
    public Animator anim;
    public Sprite[] objSprite;
    public Image playerImage;
    public Text playerText;
    public GiftType mygifttype;
    public int currentDollar;

    public int wrong›nt;
    int shakeCount;
    void Start()
    {
        plDrag = FindObjectOfType<PlayerDrag>();
        plMovement = FindObjectOfType<PlayerMovement>();
        PlayerObjChoose();
        mainCam = Camera.main;
        playerText.text = playerDollarCount.ToString();
    }

    public void PlayerObjChoose()
    {
        int rand = Random.Range(0, objSprite.Length);
        playerImage.GetComponent<Image>().sprite = objSprite[rand];

        switch (rand)
        {
            case 0:
                mygifttype = GiftType.candy;
                for (int i = 0; i < objeler.transform.childCount; i++)
                {
                    objeler.transform.GetChild(i).gameObject.SetActive(false);
                }
                objeler.transform.GetChild(rand).gameObject.SetActive(true);
                break;
            case 1:
                mygifttype = GiftType.gum;
                for (int i = 0; i < objeler.transform.childCount; i++)
                {
                    objeler.transform.GetChild(i).gameObject.SetActive(false);
                }
                objeler.transform.GetChild(rand).gameObject.SetActive(true);
                break;
            case 2:
                mygifttype = GiftType.chocolate;
                for (int i = 0; i < objeler.transform.childCount; i++)
                {
                    objeler.transform.GetChild(i).gameObject.SetActive(false);
                }
                objeler.transform.GetChild(rand).gameObject.SetActive(true);
                break;
            default:
                break;
        }
        anim.SetTrigger("OpenHand");
        currentDollar = Random.Range(10, 40);
        GameManager.instance.handUi.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "$" + currentDollar.ToString();
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void shakeCam()
    {
        if (shakeCount < 10)
        {
            mainCam.transform.DOLocalMove(new Vector3(0.01f, -0.01f, mainCam.transform.localEulerAngles.z), 0.01f).OnComplete(() =>
            {
                mainCam.transform.DOLocalMove(new Vector3(0, 0, 0f), 0.01f).OnComplete(() =>
                {
                    mainCam.transform.DOLocalMove(new Vector3(0.01f, 0.01f, 0f), 0.01f).OnComplete(() =>
                    {
                        mainCam.transform.DOLocalMove(new Vector3(0, 0, 0f), 0.01f).OnComplete(() => shakeCam());
                    });
                });
            });
            shakeCount++;
        }
        else
        {
            print("b");
            shakeCount = 0;
            plMovement.isGo = true;
            plDrag._sensitivity = 0.2f;
        }
    }

    public void FallCam()
    {
        if (shakeCount < 10)
        {
            mainCam.transform.DOLocalMove(new Vector3(0.01f, -0.01f, mainCam.transform.localEulerAngles.z), 0.01f).OnComplete(() =>
            {
                mainCam.transform.DOLocalMove(new Vector3(0, 0, 0f), 0.01f).OnComplete(() =>
                {
                    mainCam.transform.DOLocalMove(new Vector3(0.01f, 0.01f, 0f), 0.01f).OnComplete(() =>
                    {
                        mainCam.transform.DOLocalMove(new Vector3(0, 0, 0f), 0.01f).OnComplete(() => FallCam());
                    });
                });
            });
            shakeCount++;
        }
        else
        {
            mainCam.transform.DOLocalRotateQuaternion(Quaternion.Euler(-90, 0, 0), 0.5f).OnComplete(() =>
               {
                   mainCam.transform.GetChild(0).gameObject.SetActive(true);
                   GameManager.instance.GameFail();
               });
        }
    }
    public void GetPunch()
    {
        if (wrong›nt < 2)
        {
            shakeCam();
        }
        else
        {
            FallCam();
        }
        wrong›nt++;
    }

}
