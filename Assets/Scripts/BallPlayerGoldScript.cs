using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BallPlayerGoldScript : MonoBehaviour
{
    Canvas canvasMain;

    private void Start()
    {
        canvasMain = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            GameObject current = Instantiate(Resources.Load<GameObject>("GoldImage"), canvasMain.transform);
            Vector3 goldpos = Camera.main.WorldToScreenPoint(this.transform.position);
            current.transform.position = goldpos;
            current.transform.DOLocalMove(canvasMain.transform.GetChild(0).transform.localPosition, 1f).OnComplete(() =>
            {
                Destroy(current);
            });
        }
    }
}
