using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoZombie : MonoBehaviour
{
    [SerializeField] public int ruta;
    [SerializeField] public float crono;
    [SerializeField] public Quaternion angulo;
    [SerializeField] public float grado;
    [SerializeField] public float deteccion;
    [SerializeField] public float vel;

    [SerializeField] public GameObject jugador;

    [SerializeField] public NavMeshAgent agente;


    void Start()
    {
        jugador = GameObject.Find("Personaje");
    }

    void Update()
    {
        Comportamiento();
    }

    public void Comportamiento()
    {
        if (Vector3.Distance(transform.position, jugador.transform.position) > deteccion)
        {
            agente.enabled = false;
            crono += 1 * Time.deltaTime;
            if (crono >= 4)
            {
                ruta = Random.Range(0, 2);
                crono = 0;
            }
            switch (ruta)
            {
                case 0:
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    ruta++;

                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * vel * Time.deltaTime);

                    break;

            }
        }

        else
        {
            var miraPos = jugador.transform.position - transform.position;
            miraPos.y = 0;
            var rotacion = Quaternion.LookRotation(miraPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacion, 3);

            transform.Translate(Vector3.forward * 2 * Time.deltaTime);

            agente.enabled = true;
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, deteccion);
    }
}
