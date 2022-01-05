using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Sprite[] objSprite;
    public Image playerImage;
    public GiftType mygifttype;
    // Start is called before the first frame update
    void Start()
    {
        PlayerObjChoose();
    }

    public void PlayerObjChoose()
    {
        int rand = Random.Range(0,objSprite.Length);
        playerImage.GetComponent<Image>().sprite = objSprite[rand];

        switch (rand)
        {
            case 0:
                mygifttype = GiftType.candy;
                break;
            case 1:
                mygifttype = GiftType.gum;
                break;
            case 2:
                mygifttype = GiftType.chocolate;
                break;
            default:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
