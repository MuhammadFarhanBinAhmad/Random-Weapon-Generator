using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    public GameObject endgame_UI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerManager>() !=null)
        {
            Cursor.lockState = CursorLockMode.None;
            endgame_UI.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
