using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMazeSize : MonoBehaviour
{
    InputField input;
    [SerializeField] private bool isX;

    private void Start()
    {
        input = gameObject.GetComponent<InputField>();
        //set the sizetext correctly to the value
        if (isX) input.text = MazeGen.instance.GetsizeX().ToString();
        else input.text = MazeGen.instance.GetsizeY().ToString();
    }
    public void SetSizeX()
    {
        MazeGen.instance.SetSizeX(int.Parse(input.text));
        //set the sizetext correctly to the value
        input.text = MazeGen.instance.GetsizeX().ToString();
    }
    public void SetSizeY()
    {
        MazeGen.instance.SetSizeY(int.Parse(input.text));
        //set the sizetext correctly to the value
        input.text = MazeGen.instance.GetsizeY().ToString();
    }
}
