using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraDeVida : MonoBehaviour
{
    [SerializeField] private Image relleno;
    [SerializeField] public float vMax;
    [SerializeField] public float vAct;
    [SerializeField] public float tiempoVeneno;


    void Update()
    {
        Salud();
    }

    public void Salud()
    {
        relleno.fillAmount = vAct / vMax;
    }

    public void Dañado(float danio)
    {
        vAct -= danio;
        if (vAct == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Recuperacion(float cura)
    {
        vAct += cura;
        if (vAct > vMax)
        {
            vAct = vMax;
        }
    }
    public void Veneno(float veneno)
    {
        vAct -= veneno * tiempoVeneno;
    }

  
}
