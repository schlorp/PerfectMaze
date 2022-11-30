using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public List<GameObject> walls = new List<GameObject>();
    public void RemoveWall(int wallindex)
    {
        Destroy(walls[wallindex]);
    }
}
