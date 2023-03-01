using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public enum Levels { Menu = 0, Level01 = 1, Level02 = 2 };    //guardar nombre de los niveles

    public void ChangeLevel(Levels level)
    {
        SceneManager.LoadScene((int)level);
    }

    public void ChangeLevel(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1f;
    }

   
}