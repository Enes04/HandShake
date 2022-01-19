using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPeoples : MonoBehaviour
{
    public List<GameObject> peoples;
    GameObject finishPoints;
    void Start()
    {
        finishPoints = GameObject.FindGameObjectWithTag("finishpoints");
    }

    void Update()
    {

    }

    public void addPeople(GameObject people)
    {
        GameObject currentPeople = people.GetComponentInParent<Enemy>().gameObject;
        peoples.Add(currentPeople);
    }

    public void PeopleLine()
    {
        for (int i = 0; i < peoples.Count; i++)
        {
            peoples[i].transform.position = finishPoints.transform.GetChild(i).transform.position;
            peoples[i].GetComponent<Enemy>().enemyDollarText.transform.parent.gameObject.SetActive(false);
            int rand = Random.Range(0, 2);
            if (rand == 0)
                peoples[i].GetComponentInChildren<Animator>().SetTrigger("dance");
            else if(rand == 1)
                peoples[i].GetComponentInChildren<Animator>().SetTrigger("dance");
        }
    }
}
