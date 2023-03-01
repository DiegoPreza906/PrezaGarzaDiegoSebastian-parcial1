using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOver : MonoBehaviour
{
    public enum Levels { Menu = 0, Level01 = 1, Level02 = 2 };

    [SerializeField] private GameObject menuGameover;

    private LifePlayer change;

    private void Start()
    {
        change=GameObject.FindGameObjectWithTag("Player").GetComponent<LifePlayer>();
        change.MuerteJugador += OnMenu;
    }

    private void OnMenu(object sender,EventArgs e)
    {
        menuGameover.SetActive(true);
    }

}
