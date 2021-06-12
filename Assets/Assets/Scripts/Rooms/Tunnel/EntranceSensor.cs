using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceSensor : MonoBehaviour
{
    ///Script summary///
    ///Open and close door
    ///
    /// 
    ///

    public Animator the_anim;

    private void Start()
    {
        the_anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerManager>())
        {
            the_anim.SetTrigger("OpenDoor");
        }
    }
}
