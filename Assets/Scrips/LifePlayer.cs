using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Video;

public class LifePlayer : MonoBehaviour
{
    [SerializeField] private int life;

    public event EventHandler MuerteJugador;

    public void GetDamage(int cantidadDanio)
    {
        life -= cantidadDanio;
        if(life<=0)
        {
            MuerteJugador?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }

}
