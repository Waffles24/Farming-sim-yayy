using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int strawberriesCollected;
    private void Update()
    {
        if (strawberriesCollected == 1)
        {
            print("You have " + strawberriesCollected + " strawberry");
        }
        else
        {
            print("You have " + strawberriesCollected + " strawberries");
        }
    }
}
