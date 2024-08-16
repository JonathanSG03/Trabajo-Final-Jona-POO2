using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour, IInteractable
{
    private Animator animacion;
    [SerializeField] private string abrirAnima;
    [SerializeField] private string cerrarAnim;
    private bool cerrado = true;

    void Start()
    {
        animacion = GetComponent<Animator>();
    }

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animacion.Play(abrirAnima);
            cerrado = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && cerrado == false)
        {
            animacion.Play(cerrarAnim);
            cerrado = true;
        }
    }

}
