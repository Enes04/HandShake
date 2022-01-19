using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    public GameObject hand;
    Color newColor;
    void Start()
    {
        newColor = new Color(1, 0.0584795f, 0, 0.3843137f);
        hand.GetComponent<MeshRenderer>().material.color = newColor;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hand"))
        {
         //   hand.SetActive(true);
        }

        if (other.CompareTag("Body"))
        {
          //  hand.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Hand"))
        {
            //newColor = new Color(0.1754458f, 20.839622614f, 0.1703008f, 0.3843137f);
            other.GetComponentInParent<EnemyCollider>().transform.parent.GetComponentInChildren<Outline>().enabled = true;
            //hand.GetComponent<MeshRenderer>().material.color = newColor;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            //newColor = new Color(1, 0.0584795f, 0, 0.3843137f);
            other.GetComponentInParent<EnemyCollider>().transform.parent.GetComponentInChildren<Outline>().enabled = false;
            //hand.GetComponent<MeshRenderer>().material.color = newColor;
        }
    }
}
