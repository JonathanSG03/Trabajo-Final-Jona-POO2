using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Inventory : MonoBehaviour
{

    [SerializeField] internal List<GameObject> inventory;
    [SerializeField] private int itemsInInventory; 
    [SerializeField] private int maxCapacity; 


    public void AddItem(GameObject item)
    {
        if(itemsInInventory < maxCapacity)
        {
            inventory.Add(item);
            itemsInInventory++;
        }
        else
        {
            Debug.Log("No hay espacio en el inventario");
        }
    }

    public void RemoveItem(GameObject item)
    {
        if (inventory.Contains(item))
        {
            inventory.Remove(item);
            itemsInInventory--;
        }
        else
        {
            Debug.Log("Ese objeto no se encuentra en el inventario");
        }
    }

    public bool ContainsItem(GameObject item)
    {
        return inventory.Contains(item);
    }


}
