using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    PlayerMovement plMovement;
    PlayerDrag plDrag;

    private void Start()
    {
        plMovement = FindObjectOfType<PlayerMovement>();
        plDrag = FindObjectOfType<PlayerDrag>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hand"))
        {
            plMovement.isGo = false;
            plDrag._sensitivity = 0;
        }
        if (other.CompareTag("Body"))
        {
            plMovement.isGo = false;
            plDrag._sensitivity = 0;
        }
    }
}
