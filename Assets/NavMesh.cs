using NavMeshPlus.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMesh : MonoBehaviour
{
    public NavMeshSurface Surface2D;
    // Start is called before the first frame update
    void Start()
    {
        Surface2D.BuildNavMeshAsync();
    }

    // Update is called once per frame
    void Update()
    {
        Surface2D.UpdateNavMesh(Surface2D.navMeshData);
    }
}
