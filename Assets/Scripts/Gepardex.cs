using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gepardex : MonoBehaviour
{
    [SerializeField] private float soyVeloz;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.GetComponent<CharacterMove>().MasVelocidad(soyVeloz);
        }
    }
}
