using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour, IInteractable
{
    private Inventory inventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void Interact()
    {
        inventory.AddItem(this.gameObject);

        gameObject.SetActive(false);
    }
  
}
