using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    //detect collision
    //add item to player
    //destroy object
    [SerializeField] Transform Collision_Checker;

    public Inventory inventory_Script;
    public GameObject strawberry;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (strawberry.gameObject)
        {
            inventory_Script.strawberriesCollected++;
            Destroy(other.gameObject);
        }

    }
    


}
