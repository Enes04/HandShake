using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPunchScript : MonoBehaviour
{
    Player pl;
    void Start()
    {
        pl = FindObjectOfType<Player>();
    }
    public void PunchForPlayer()
    {
        pl.GetPunch();
    }
    void Update()
    {

    }
}
