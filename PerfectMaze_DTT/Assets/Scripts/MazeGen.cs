using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGen : MonoBehaviour
{
    public Node PrefabNode;
    public Vector2Int size;
    public List<Node> Nodes = new List<Node>();
    List<Node> currentNodes = new List<Node>();
    List<Node> completed = new List<Node>();
    int index;


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

        index = Random.Range(0, Nodes.Count);
        currentNodes.Add(Nodes[index]);
        currentNodes[0].SetState(States.current);

        StartCoroutine(CreateMaze());
    }

    public IEnumerator CreateMaze()
    {
        while(currentNodes.Count < Nodes.Count)
        {
            int currentNodeIndex = Nodes.IndexOf(currentNodes[currentNodes.Count - 1]);
            List<int> possible = new List<int>();

            //check upper
            if (currentNodeIndex + size.y < Nodes.Count)
            {
                if(!completed.Contains(Nodes[currentNodeIndex + size.y]) || !currentNodes.Contains(Nodes[currentNodeIndex + size.y]))
                {
                    possible.Add(0);
                }
            }
            //check lower
            if (currentNodeIndex - size.y > 0)
            {
                if (!completed.Contains(Nodes[currentNodeIndex - size.y]) || !currentNodes.Contains(Nodes[currentNodeIndex - size.y]))
                {
                    possible.Add(1);
                }
            }
            //check right
            if (currentNodeIndex + size.x < Nodes.Count)
            {
                if (!completed.Contains(Nodes[currentNodeIndex + size.x]) || currentNodes.Contains(Nodes[currentNodeIndex + size.x]))
                {
                    possible.Add(2);
                }
            }
            //check left
            if (currentNodeIndex - size.x > 0)
            {
                if (!completed.Contains(Nodes[currentNodeIndex - size.x]) || currentNodes.Contains(Nodes[currentNodeIndex - size.x]))
                {
                    possible.Add(3);
                }
            }

            //choose a random side of the possible nodes
            if(possible.Count == 0)
            {
                //backtrack
                Debug.Log("BackTraks");
            }
            else
            {
                int chosenindex = Random.Range(0, possible.Count);

                switch (chosenindex)
                {
                    case 0:
                        //top
                        Nodes[currentNodeIndex + 1].SetState(States.current);
                        currentNodes.Add(Nodes[currentNodeIndex + 1]);
                        break;
                    case 1:
                        //bottom
                        Nodes[currentNodeIndex - 1].SetState(States.current);
                        currentNodes.Add(Nodes[currentNodeIndex - 1]);
                        break;
                    case 2:
                        //right
                        Nodes[currentNodeIndex + size.x].SetState(States.current);
                        currentNodes.Add(Nodes[currentNodeIndex + size.x]);
                        break;
                    case 3:
                        //left
                        Nodes[currentNodeIndex - size.x].SetState(States.current);
                        currentNodes.Add(Nodes[currentNodeIndex - size.x]);
                        break;
                }
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
}
