using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGen : MonoBehaviour
{
    public Node PrefabNode;
    public Vector2Int size;
    public List<Node> Nodes = new List<Node>();


    void Start()
    {
        Generate();
    }
    

    public void Generate()
    {
        //generating the maze
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Vector3 newNodePos = new Vector3(x - (size.x / 2f), 0, y - (size.y / 2f));
                Node newNode = Instantiate(PrefabNode, newNodePos, Quaternion.identity, transform);
                Nodes.Add(newNode);
            }
        }

        List<Node> currentNodes = new List<Node>();
        List<Node> completed = new List<Node>();

        currentNodes.Add(Nodes[Random.Range(0, Nodes.Count)]);
        currentNodes[0].SetState(States.current);

        for (int i = 0; i < Nodes.Count; i++)
        {
            //check upper
            if(Nodes[i + 1] != null)
            {

            }
            //check lower
            if (Nodes[i - 1] != null)
            {

            }
            //check right
            if(Nodes[i + size.x] != null)
            {

            }
            //check left
            if (Nodes[i - size.x] != null)
            {

            }
        }
    }
}
