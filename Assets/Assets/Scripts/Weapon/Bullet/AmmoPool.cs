using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPool : MonoBehaviour
{
    public GameObject bullet;
    public int pooled_Amount = 100;
    internal List<GameObject> bullet_Pool = new List<GameObject>();

    private void Start()
    {
        //creating object pool of ammo game object
        for (int i = 0; i <= pooled_Amount; i++)
        {
            GameObject O = Instantiate(bullet);
            bullet_Pool.Add(O);
            O.SetActive(false);
            GameObject.DontDestroyOnLoad(O);
        }
    }

}
