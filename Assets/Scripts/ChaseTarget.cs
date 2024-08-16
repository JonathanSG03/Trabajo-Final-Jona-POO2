using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseTarget : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private bool chasingTarget;

    private NavMeshAgent agent;
    private Patroll patroll;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patroll = GetComponent<Patroll>();
    }

    private void Update()
    {
        // Si, la distancia entre el enemigo y el player es menor que 8, y no esta persiguiendo algo
        if (Vector3.Distance(transform.position, target.position) < 8f && !chasingTarget)
        {
            patroll.StopAllCoroutines(); // Deja de patrullar
            chasingTarget = true; // Empieza a perseguir al jugador
        }

        if (chasingTarget) // Si, esta persiguiendo al player
        {
            agent.destination = target.position; // Corre hacia el
            if (Vector3.Distance(transform.position, target.position) > 15f) // Pero, si el jugador, ya se encuentra
                // a 15 metros de distancia
            {
                chasingTarget = false; // lo deja de perseguir
                patroll.RegresarAPatrullar(); // y regresa a patrullar
            }
        }
    }

}
