using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaco : MonoBehaviour
{
    [SerializeField] private RaycastHit hit;
    [SerializeField] public float distance;
    private Transform cam;
    private ParticleSystem part;
    [SerializeField] public float fuerza;
    [SerializeField] public int danioEnemigo;

    [SerializeField] public GameObject coleccionar;

    [SerializeField] public Transform partM;

    private void Start()
    {
        cam = transform.parent;
        part = transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            part.Play();
            if (Physics.Raycast(cam.position, cam.forward, out hit, distance))
            {
                Debug.Log(hit.transform.name);
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(hit.normal * -fuerza);
                }

                if (hit.transform.tag == "Enemy")
                {
                    hit.transform.GetComponent<VidaEnemigo>().Danio(danioEnemigo);
                    Instantiate(partM, hit.point, partM.rotation);
                }

                if (hit.transform.tag == "Box")
                {
                    coleccionar = hit.transform.gameObject;
                    hit.transform.parent = transform.parent;
                    hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                }

            }
            
        }

        if (Input.GetMouseButtonDown(1))
        {
            
            if (coleccionar != null)
            {
                coleccionar.GetComponent<Rigidbody>().isKinematic=false;
                coleccionar.transform.parent = null;
                coleccionar = null;
            }
        }
        
    }








}
