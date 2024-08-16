using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour, IInteractable
{
    public bool activado = false;
    [SerializeField] public GameObject boton;

    public void Interact()
    {
        activado = true;
        
    }
}
