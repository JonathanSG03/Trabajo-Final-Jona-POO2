using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veneno : MonoBehaviour
{

    [SerializeField] public float veneno;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.GetComponent<BarraDeVida>().Veneno(veneno);
            other.GetComponent<CharacterMove>().Envenenamiento();

        }
    }
}
