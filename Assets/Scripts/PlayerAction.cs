using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    PlayerMovement plMovement;
    PlayerDrag plDrag;
    Player pl;
    private void Start()
    {
        plMovement = FindObjectOfType<PlayerMovement>();
        plDrag = FindObjectOfType<PlayerDrag>();
        pl = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hand"))
        {
            plMovement.isGo = false;
            plDrag._sensitivity = 0;
            if (other.GetComponentInParent<Enemy>().mygiftType == pl.mygifttype)
            {
                print("BAÞARILI");
            }
            else
            {
                print("YUMRUK");
            }
        }
        if (other.CompareTag("Body"))
        {
            plMovement.isGo = false;
            plDrag._sensitivity = 0;
        }
    }
}
