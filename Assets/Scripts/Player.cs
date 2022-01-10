using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Player : MonoBehaviour
{
    PlayerMovement plMovement;
    Camera mainCam;
    PlayerDrag plDrag;
    public Animator anim;
    public Sprite[] objSprite;
    public Image playerImage;
    public GiftType mygifttype;

    public int wrong›nt;
    int shakeCount;
    void Start()
    {
        plDrag = FindObjectOfType<PlayerDrag>();
        plMovement = FindObjectOfType<PlayerMovement>();
        PlayerObjChoose();
        mainCam = Camera.main;
        anim.SetTrigger("OpenHand");
    }
    
    public void PlayerObjChoose()
    {
        int rand = Random.Range(0, objSprite.Length);
        playerImage.GetComponent<Image>().sprite = objSprite[rand];

        switch (rand)
        {
            case 0:
                mygifttype = GiftType.candy;
                break;
            case 1:
                mygifttype = GiftType.gum;
                break;
            case 2:
                mygifttype = GiftType.chocolate;
                break;
            default:
                break;
        }
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
