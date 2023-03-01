using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    [SerializeField] private GameObject botonPause;
    [SerializeField] private GameObject menuPause;


    public void Pausa()
    {
        Time.timeScale= 0f;
        botonPause.SetActive(false);
        menuPause.SetActive(true);
    }

    public void Reanudar()
    {
        Time.timeScale= 1f;
        botonPause.SetActive(true);
        menuPause.SetActive(false);
    }

    public void Cerrar()
    {
        
    }
}
