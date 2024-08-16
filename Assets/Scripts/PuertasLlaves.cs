using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertasLlaves : MonoBehaviour, IInteractable
{
    private Animator animacion;
    [SerializeField] private string abrirAnima;
    [SerializeField] private string bloqueadoAnim;
    private Inventory bolsas;
    [SerializeField] private GameObject llave;
    

    void Start()
    {
        animacion = GetComponent<Animator>();
        bolsas = FindAnyObjectByType<Inventory>();
    }

    public void Interact()
    {
        if (bolsas.ContainsItem(llave))
        {
            animacion.Play(abrirAnima);
            
        }
        else 
        {
            animacion.Play(bloqueadoAnim);
        }
    }
}
