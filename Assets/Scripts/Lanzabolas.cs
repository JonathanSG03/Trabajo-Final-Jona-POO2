using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzabolas : MonoBehaviour
{
    public GameObject bola;
    public float forcea;

void Update()
    {
        if (Input.GetMouseButtonDown(0))  //Este es para disparar una sola bala
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject clon = Instantiate(bola, transform.GetChild(i).position, transform.GetChild(i).rotation);
                clon.GetComponent<Rigidbody>().AddForce(transform.GetChild(i).forward * forcea);
                Destroy(clon, 3);
            }


        }


    }
}
