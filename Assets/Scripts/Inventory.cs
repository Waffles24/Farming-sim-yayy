using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/*stuff to do
    a) detect collision
    b) add 1 to amount
    c) destroy game object

    d) check if item already exists in slot
    e) check if item is at max capacity
    f) if item satisfies above create new slot and assign item 
    g) system for creating slots */


        /*
        a) what item is in slot,
        b) how many of item,
        c) number of items allowed in slot */

//need to keep track of item type

[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot
    {
        //count will check number of items in slot
        //maxCapacity for storing how much a slot can hold
        public CollectablesType type;
        public int count;
        public int maxCapacity;
        public Sprite icon;

        //if List<Slot> is unrecognised, make sure to include system.Collections.Generic!
        //now we have a list of slots!


        public Slot()
        {
            //this will set all our types (strawberries etc) to a default empty value
            type = CollectablesType.NONE;
            count = 0;
            maxCapacity = 99;
        }

        //this checks the slot capacity with a bool
        public bool canAddItem()
        {
            if(count < maxCapacity)
            {
               return true;
            }

            else
            {
                return false;
            }
        }

        public void AddItem(Collectables item)
        {
            this.type = item.type;
            count++;
            this.icon = item.icon;

        }

        public void RemoveItem()
        {
            if(count < 0)
            {
                count--;

                if(count == 0)
                {
                    Debug.Log("icon is null");
                    icon = null;
                    type = CollectablesType.NONE;
                }
            }
        }
    }



    public List<Slot> slots = new List<Slot>();

    //Below is a constructor! It's called when the object of it's class is created
    //note - research later
    public Inventory(int numSlots)
    {
        //a for loop is similar to a while loop, except the bounds/limits are already known.
        for (int i = 0; i < numSlots; i++)
        {
            //this creates a new slot and adds it to the list
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }


    //this class will be used to add items the player collects to the iventory
    public void Add(Collectables item)
    {
        //after collecting an item, we can search for the same item in our inventory :
        //for each will check each item in a list or array
        foreach(Slot slot in slots)
        {
            //the value of each slot space is checked against the value of the new item being added 
            //&& returns true if both statements are true
            if(slot.type == item.type && slot.canAddItem())
            {
                slot.AddItem(item);
                return;
            }
        }
            
        foreach(Slot slot in slots)
        {
            if (slot.type == CollectablesType.NONE)
            {
                slot.AddItem(item);
                return;
            }
        }
         
    }

    //we can use an index, since the slots are in a list, item 1 will be index 0, item 2 index 1 etc
    public void Remove(int index)
    {
        slots[index].RemoveItem();
    }

}
