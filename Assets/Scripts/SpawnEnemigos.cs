using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigos : MonoBehaviour
{
    [SerializeField] private Transform[] spawn;
 

    [SerializeField] private GameObject ubicado;

    private int rand;

    [SerializeField] private float tiempo;



    private void Start()
    {
        StartCoroutine(Temporizador());

    }

    IEnumerator Temporizador()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempo);
            Instantiate(ubicado, spawn[rand]);
            rand = Random.Range(0, spawn.Length);

        }
    }

}
