using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    public GameObject endgame_UI;

    private void Start()
    {
        endgame_UI = GameObject.Find("EndGameScreen");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerManager>() !=null)
        {
            endgame_UI.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
