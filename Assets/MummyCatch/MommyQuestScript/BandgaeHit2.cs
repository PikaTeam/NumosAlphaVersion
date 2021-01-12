using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandgaeHit2 : MonoBehaviour
{
    public GameObject QuestPad;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Mummy")
        {
            GameObject quest = Instantiate(QuestPad);
            quest.GetComponent<CloseQuest>().Mymummy = collision.gameObject;
            Destroy(gameObject);
        }
    }
}
