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
        CreateMaze();
    }

    public void CreateMaze()
    {

        List<Node> currentNodes = new List<Node>();
        List<Node> completed = new List<Node>();


        int index = Random.Range(0, Nodes.Count);
        currentNodes.Add(Nodes[index]);
        currentNodes[0].SetState(States.current);

        for (int i = 0; i < currentNodes.Count; i++)
        {
            int randomint = Random.Range(0, 4);

            if (currentNodes[i] == currentNodes[currentNodes.Count])
            {
                Debug.Log("wawd");
                //check upper
                if (i + 1 < Nodes.Count && randomint == 0)
                {
                    Nodes[index + 1].SetState(States.completed);
                }
                //check lower
                if (i - 1 > 0 && randomint == 1)
                {
                    Nodes[index - 1].SetState(States.completed);
                }
                //check right
                if (i + size.x < Nodes.Count && randomint == 2)
                {
                    Nodes[index + size.x].SetState(States.completed);
                }
                //check left
                if (i - size.x > 0 && randomint == 3)
                {
                    Nodes[index - size.x].SetState(States.completed);
                }
                else return;
            }
        }
    }
}
