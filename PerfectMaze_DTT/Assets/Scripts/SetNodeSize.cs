using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetNodeSize : MonoBehaviour
{
    InputField input;
    private void Start()
    {
        input = gameObject.GetComponent<InputField>();
        //set the sizetext correctly to the value
        input.text = MazeGen.instance.GetNodesize().ToString();
    }
    public void SetSize()
    {
        //setting the size in the maze class
        MazeGen.instance.SetNodeSize(int.Parse(input.text));
        //set the sizetext correctly to the value
        input.text = MazeGen.instance.GetNodesize().ToString();
    }
}
