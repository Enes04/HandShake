using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    public Collider[] colliders;
    void Start()
    {
        colliders[0] = GetComponentInChildren<EnemyHandScript>().GetComponent<Collider>();
        colliders[1] = GetComponentInChildren<BodyScript>().GetComponent<Collider>();
    }

    void Update()
    {
        
    }
}
