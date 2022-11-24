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

    private void Start()
    {
    }
    public void SetState(States state)
    {
        switch(state)
        {
            case States.unused:
                gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.white;
                break;
            case States.current:
                gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.yellow;
                break;
            case States.completed:
                gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.blue;
                break;
        }
    }
}
