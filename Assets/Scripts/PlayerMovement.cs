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
        shakeCam();
    }
    void Update()
    {
        if (isGo)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, posY, transform.position.z);
        }
        
    }
    public void shakeCam()
    {
        mainCam.transform.DOLocalMove(new Vector3(cameraposX, -camerposY, mainCam.transform.localEulerAngles.z), cameraShakeSpeed).OnComplete(() =>
        {
            mainCam.transform.DOLocalMove(new Vector3(0, 0, 0f), cameraShakeSpeed).OnComplete(() =>
            {
                mainCam.transform.DOLocalMove(new Vector3(cameraposX, camerposY, 0f), cameraShakeSpeed).OnComplete(()=>
                {
                    mainCam.transform.DOLocalMove(new Vector3(0, 0, 0f), cameraShakeSpeed).OnComplete(() => shakeCam());
                });
            });
        });
    }
}
