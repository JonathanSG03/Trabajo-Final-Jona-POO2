using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    [SerializeField] public int vida;


    [SerializeField] public int cantidadEnemigo;


    private void Start()
    {
        
    }
    public void Danio(int cantidad)
    {
        

        vida -= cantidad;
        if (vida <= 0 )
        {
            
            Destroy(this.gameObject);
           
           
            
            
        }
    }


    



}
