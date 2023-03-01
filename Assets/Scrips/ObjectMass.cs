using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMass : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    [SerializeField] private float mass;

    [SerializeField] private Puntaje puntaje;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            puntaje.PlusPoints(mass);
            Destroy(gameObject);
        }
    }
}
