using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSize : MonoBehaviour
{
    InputField input;
    [SerializeField] private bool isX;

    private void Start()
    {
        input = gameObject.GetComponent<InputField>();
        if (isX) input.text = MazeGen.instance.GetsizeX().ToString();
        else input.text = MazeGen.instance.GetsizeY().ToString();
    }
    public void SetSizeX()
    {
        Debug.Log(input);
        MazeGen.instance.SetSizeX(int.Parse(input.text));
    }
    public void SetSizeY()
    {
        Debug.Log(input);
        MazeGen.instance.SetSizeY(int.Parse(input.text));
    }
}
