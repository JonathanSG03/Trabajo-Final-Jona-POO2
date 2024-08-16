using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recuperacion : MonoBehaviour
{
    [SerializeField] public float curacion;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.GetComponent<BarraDeVida>().Recuperacion(curacion);
        }
    }
}
