using UnityEngine;
using System.Collections.Generic;


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

        public void AddItem(CollectablesType type)
        {
            this.type = type;
            count++;
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
    public void Add(CollectablesType typeToAdd)
    {
        //after collecting an item, we can search for the same item in our inventory :
        //for each will check each item in a list or array
        foreach(Slot slot in slots)
        {
            //the value of each slot space is checked against the value of the new item being added 
            //&& returns true if both statements are true
            if(slot.type == typeToAdd && slot.canAddItem())
            {
                slot.AddItem(typeToAdd);
                return;
            }
        }
            
        foreach(Slot slot in slots)
        {
            if (slot.type == CollectablesType.NONE)
            {
                slot.AddItem(typeToAdd);
                return;
            }
        }
                
    }


}
