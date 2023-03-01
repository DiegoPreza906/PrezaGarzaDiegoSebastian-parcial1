using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change : MonoBehaviour
{

    public enum Levels { PrincipalMenu = 0, Level01 = 1, Level02 = 2 };    //guardar nombre de los niveles

    public void ChangeLevel(Levels level)
    {
        SceneManager.LoadScene((int)level);
    }

    public void ChangeLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<Change>().ChangeLevel(2);

        }
    }


}
