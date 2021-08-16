using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransistion : MonoBehaviour
{

    public void ChangeScene(string Scene)
    {
        if (Scene == "MainMenu")
        {
            FindObjectOfType<AmmoPool>().DestroyAmmoPool();
            PlayerManager.ResetPlayerData();
        }
        SceneManager.LoadScene(Scene);
        Time.timeScale = 1;
    }
    public void Exitgame()
    {
        Application.Quit();
    }
}
