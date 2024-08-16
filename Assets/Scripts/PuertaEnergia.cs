using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaEnergia : MonoBehaviour, IInteractable
{
    [SerializeField] Boton boton;
    private Animator animator;
    [SerializeField] private string nombreAnim;

    void Start()
    {
        boton = GetComponent<Boton>();
        animator = GetComponent<Animator>();
        boton = FindObjectOfType<Boton>();
    }
    public void Interact()
    {
        if (boton.activado == true)
        {
            animator.Play(nombreAnim);
        }
    }
}
