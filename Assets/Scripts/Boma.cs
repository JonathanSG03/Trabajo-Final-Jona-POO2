using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boma : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<VidaEnemigo>().Danio(1);

        }
        Destroy(this.gameObject);
    }
}
