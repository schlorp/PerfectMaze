using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    unused,
    current,
    completed
}
public class Node : MonoBehaviour
{
    public List<GameObject> walls = new List<GameObject>();

    public void RemoveWall(int wallindex)
    {
        walls[wallindex].SetActive(false);
    }
    public void SetState(States state)
    {
        switch(state)
        {
            case States.unused:
                break;
            case States.current:
                break;
            case States.completed:
                break;
        }
    }
}
