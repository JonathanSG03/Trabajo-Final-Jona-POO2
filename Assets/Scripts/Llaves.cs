using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llaves : MonoBehaviour, IInteractable
{
    private Inventory bolsas;
    [SerializeField] private GameObject llave;


    void Start()
    {
        bolsas = FindObjectOfType<Inventory>();
    }

    public void Interact()
    {
        bolsas.AddItem(llave);
        llave.SetActive(false);
    }
}
