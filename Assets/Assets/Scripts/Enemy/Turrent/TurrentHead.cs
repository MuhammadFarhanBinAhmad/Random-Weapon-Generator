using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentHead : MonoBehaviour
{

    Transform player;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {
            if (hit.transform.GetComponent <PlayerManager>() !=null)
            {
                player = hit.transform.GetComponent<PlayerManager>().transform;
                print("hit" + hit.distance);
            }
            else
            {
                player = null;
            }
        }
        if (player != null)
        {
            transform.LookAt(player);
        }

        //transform.Rotate(0, 1, 0);
    }
    /*void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(transform.forward) * 100;
        Gizmos.DrawRay(transform.position, direction);
    }*/
}
