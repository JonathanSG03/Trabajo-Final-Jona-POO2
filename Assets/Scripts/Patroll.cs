using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroll : MonoBehaviour
{

    [SerializeField] public Transform[] puntosDePatrullaje; // Los puntos hacia donde puede ir a patrullar el enemigo
    [SerializeField] private Transform ultimoPuntoVisitado; // El ultimo punto que visito
    [SerializeField] float tiempoDeVigilancia; // Cuanto tiempo va a durar en el punto cuando llegue, antes de ir a otro punto

    private int ultimoPuntoRandom = 0; // El indice de el ultimo punto que visito
    private bool regresoAPatrullar = false; // Bool de si esta regresando a patrullar despues de ser interrumpido

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Patrullar());
    }

    private IEnumerator Patrullar()
    {
        if (regresoAPatrullar) // Si, fue interrumpido al patrullar, y esta regresando
        {
            agent.destination = ultimoPuntoVisitado.position; // Se dirige al ultimo punto al que iba
            yield return new WaitUntil(() => Vector3.Distance(this.transform.position, ultimoPuntoVisitado.position) < 1.5f); // Revisa si ya llego al punto

            yield return new WaitForSeconds(tiempoDeVigilancia); // Se espera un tiempo para vigilar el area

            regresoAPatrullar = false; // Desactivamos el bool porque ya regreso a su labor normal

            StartCoroutine(Patrullar()); // Vuelve a patrullar
        }
        else // En caso, que sea la primera vez que patrulle o ya despues de visitar su ultimo punto de patrullaje
        {
            agent.destination = puntosDePatrullaje[PuntoRandom()].position; // Escoge un punto random al cual ir
            ultimoPuntoVisitado = puntosDePatrullaje[ultimoPuntoRandom]; // Se guarda ese punto

            yield return new WaitUntil(() => Vector3.Distance(this.transform.position, puntosDePatrullaje[ultimoPuntoRandom].position) < 1.5f); // Se espera hasta llegar

            yield return new WaitForSeconds(tiempoDeVigilancia); // Vigila un tiempo esa area

            StartCoroutine(Patrullar()); // Regresa a patrullar
        }
    }

    public void RegresarAPatrullar()
    {
        regresoAPatrullar = true;
        StartCoroutine(Patrullar());
    }


    private int PuntoRandom()
    {
        int random = Random.Range(0, puntosDePatrullaje.Length); // Consiguen un punto random de el arreglo de puntos de patrullaje
        while(random == ultimoPuntoRandom) // pregunta si el punto conseguido es igual al ultimo visitado
        {
            // si si, se vuelve a randomizar hasta conseguir que sea diferente al ultimo punto
            random = Random.Range(0, puntosDePatrullaje.Length);
            //Esto para que no visite 2 veces el mismo punto uno despues del otro
        }
        ultimoPuntoRandom = random;

        return random;
        
    }

}
