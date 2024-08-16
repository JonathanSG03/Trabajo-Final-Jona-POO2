using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Muerto : MonoBehaviour
{
    [SerializeField] public float fuerza;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.GetComponent<BarraDeVida>().Dañado(fuerza);
        }
    }
}
