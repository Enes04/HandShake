using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    public GameObject hand;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       // RayCastObj();
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Hand"))
        {

        }
    }
}
