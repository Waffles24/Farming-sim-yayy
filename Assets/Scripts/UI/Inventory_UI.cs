using UnityEngine;
using System.Collections.Generic;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Player player;
    public List<Slots_UI> slots = new List<Slots_UI>();

    private void Start()
    {
        inventoryPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }


    public void ToggleInventory()
    {
        // ! means not - so this is : "if [inventoryPanel is not open,] execute x"
        if(!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Setup();
        }

        else
        {
            inventoryPanel.SetActive(false);
        }
    }


    void Setup()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if(player.inventory.slots[i].type != CollectablesType.NONE)
            {
                slots[i].SetItem(player.inventory.slots[i]);
            }

            else
            {
                slots[i].SetEmpty();
            }
        }
    }



}
