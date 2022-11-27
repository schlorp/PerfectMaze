using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGen : MonoBehaviour
{
    public Node PrefabNode;
    public Vector2Int size;
    List<Node> Nodes = new List<Node>();
    List<Node> currentNodes = new List<Node>();
    List<Node> completed = new List<Node>();


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

        currentNodes.Add(Nodes[Random.Range(0, Nodes.Count)]);
        currentNodes[0].SetState(States.current);

        StartCoroutine(CreateMaze());
    }

    public IEnumerator CreateMaze()
    {
        while(completed.Count < Nodes.Count)
        {
            List<int> possible = new List<int>();
            List<int> possibleNode = new List<int>();

            int currentNodeIndex = Nodes.IndexOf(currentNodes[currentNodes.Count - 1]);
            int currentNodeX = currentNodeIndex / size.y;
            int currentNodeY = currentNodeIndex % size.y;
            

            if (currentNodeX < size.x - 1)
            {
                //check right
                if(!completed.Contains(Nodes[currentNodeIndex + size.y]) && !currentNodes.Contains(Nodes[currentNodeIndex + size.y]))
                {
                    possible.Add(1);
                    possibleNode.Add(currentNodeIndex + size.y);
                }
            }
            if (currentNodeX > 0)
            {
                //check left
                if (!completed.Contains(Nodes[currentNodeIndex - size.y]) && !currentNodes.Contains(Nodes[currentNodeIndex - size.y]))
                {
                    possible.Add(2);
                    possibleNode.Add(currentNodeIndex - size.y);
                }
            }
            if (currentNodeY < size.y - 1)
            {
                //check top
                if (!completed.Contains(Nodes[currentNodeIndex + 1]) && !currentNodes.Contains(Nodes[currentNodeIndex + 1]))
                {
                    possible.Add(3);
                    possibleNode.Add(currentNodeIndex + 1);
                }
            }
            if (currentNodeY > 0)
            {
                //check bottom
                if (!completed.Contains(Nodes[currentNodeIndex - 1]) && !currentNodes.Contains(Nodes[currentNodeIndex - 1]))
                {
                    possible.Add(4);
                    possibleNode.Add(currentNodeIndex - 1);
                }
            }


            if(possible.Count > 0)
            {
                int chosenindex = Random.Range(0, possible.Count);
                Node chosennode = Nodes[possibleNode[chosenindex]];

                switch (possible[chosenindex])
                {
                    case 1:
                        chosennode.RemoveWall(1);
                        currentNodes[currentNodes.Count - 1].RemoveWall(0);
                        break;
                    case 2:
                        chosennode.RemoveWall(0);
                        currentNodes[currentNodes.Count - 1].RemoveWall(1);
                        break;
                    case 3:
                        chosennode.RemoveWall(3);
                        currentNodes[currentNodes.Count - 1].RemoveWall(2);
                        break;
                    case 4:
                        chosennode.RemoveWall(2);
                        currentNodes[currentNodes.Count - 1].RemoveWall(3);
                        break;
                }

                currentNodes.Add(chosennode);
                chosennode.SetState(States.current);
            }
            else
            {
                completed.Add(currentNodes[currentNodes.Count - 1]);
                currentNodes[currentNodes.Count - 1].SetState(States.completed);
                currentNodes.RemoveAt(currentNodes.Count - 1);
            }
            yield return new WaitForSeconds(.01f);
        }
    }
}
