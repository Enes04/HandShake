using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    Camera mainCam;
    public float cameraShakeSpeed;
    public float camerposY;
    public float cameraposX;
    public bool isGo;
    public float speed;
    public float posY;

    void Start()
    {
        mainCam = Camera.main;
     //   shakeCam();
    }
    void Update()
    {
        if (isGo)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, posY, transform.position.z);
        }
        
    }
    public void transformKill()
    {
        mainCam.transform.DOKill();
    }

    public void shakeCam()
    {
        mainCam.transform.localPosition = new Vector3(0, 0, 0);
        mainCam.transform.DOLocalMove(new Vector3(0.01f, -0.01f,0), cameraShakeSpeed).OnComplete(() =>
        {
            mainCam.transform.DOLocalMove(new Vector3(0, 0, 0f), cameraShakeSpeed).OnComplete(() =>
            {
                mainCam.transform.DOLocalMove(new Vector3(0.01f, 0.01f, 0f), cameraShakeSpeed).OnComplete(()=>
                {
                    mainCam.transform.DOLocalMove(new Vector3(0, 0, 0f), cameraShakeSpeed).OnComplete(() => shakeCam());
                });
            });
        });
    }
}
