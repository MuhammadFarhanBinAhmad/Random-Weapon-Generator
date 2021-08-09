using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GenerateNavMesh : MonoBehaviour
{

    public NavMeshSurface surface;

    // Start is called before the first frame update
    void Start()
    {
        surface.BuildNavMesh();
    }
}
