using System.Collections.Generic;
using System.Collections;
using UnityEngine;

// SCRIPT AIM :

//detect collision
//add item to player
//destroy object


public class Collectables : MonoBehaviour
{

    public CollectablesType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player)
        {
            player.inventory.Add(type);
            Destroy(this.gameObject);
        }

    }

}
public enum CollectablesType
    //an enum can represent a list of string names, all assigned a numeric value
    //in this case NONE = 0, STRAWBERRY_SEEDS = 1 etc
{
    NONE, STRAWBERRY_SEEDS, CARROT_SEEDS, TOMATO_SEEDS
}