using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGen : MonoBehaviour
{
    //singleton
    public static MazeGen instance;

    //variables
    public Node PrefabNode;
    [SerializeField] private Vector2Int size;
    List<Node> Nodes = new List<Node>();
    List<Node> currentNodes = new List<Node>();
    List<Node> completed = new List<Node>();

    //checking singleton
    private void Awake()
    {
        if (instance != null && instance != this) Destroy(this);
        else instance = this;
    }
    public void Generate()
    {
        //clearing the lists if they are filled (for Regenerations)
        if(Nodes.Count > 0)
        {
            foreach (Node node in Nodes)
            {
                Destroy(node.gameObject);
            }
            Nodes.Clear();
            currentNodes.Clear();
            completed.Clear();
        }

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

        //choose a random starting node
        currentNodes.Add(Nodes[Random.Range(0, Nodes.Count)]);
        CreateMaze();
    }

    public void CreateMaze()
    {
        //while there are still nodes left to check this runs
        while(completed.Count < Nodes.Count)
        {
            List<int> possible = new List<int>();
            List<int> possibleNode = new List<int>();

            int currentNodeIndex = Nodes.IndexOf(currentNodes[currentNodes.Count - 1]);
            int currentNodeX = currentNodeIndex / size.y;
            int currentNodeY = currentNodeIndex % size.y;
            
            //check if for every direction if there is a node
            if (currentNodeX < size.x - 1)
            {
                //check if RightNode is in the current or completed node list
                if (!completed.Contains(Nodes[currentNodeIndex + size.y]) && !currentNodes.Contains(Nodes[currentNodeIndex + size.y]))
                {
                    possible.Add(1);
                    possibleNode.Add(currentNodeIndex + size.y);
                }
            }
            if (currentNodeX > 0)
            {
                //check if LeftNode is in the current or completed node list
                if (!completed.Contains(Nodes[currentNodeIndex - size.y]) && !currentNodes.Contains(Nodes[currentNodeIndex - size.y]))
                {
                    possible.Add(2);
                    possibleNode.Add(currentNodeIndex - size.y);
                }
            }
            if (currentNodeY < size.y - 1)
            {
                //check if TopNode is in the current or completed node list
                if (!completed.Contains(Nodes[currentNodeIndex + 1]) && !currentNodes.Contains(Nodes[currentNodeIndex + 1]))
                {
                    possible.Add(3);
                    possibleNode.Add(currentNodeIndex + 1);
                }
            }
            if (currentNodeY > 0)
            {
                //check if BottomNode is in the current or completed node list
                if (!completed.Contains(Nodes[currentNodeIndex - 1]) && !currentNodes.Contains(Nodes[currentNodeIndex - 1]))
                {
                    possible.Add(4);
                    possibleNode.Add(currentNodeIndex - 1);
                }
            }

            //choose a random node from the possiblenodes
            if(possible.Count > 0)
            {
                int chosenindex = Random.Range(0, possible.Count);
                Node chosennode = Nodes[possibleNode[chosenindex]];

                switch (possible[chosenindex])
                {
                    //remove right walls
                    case 1:
                        chosennode.RemoveWall(1);
                        currentNodes[currentNodes.Count - 1].RemoveWall(0);
                        break;
                    //remove left walls
                    case 2:
                        chosennode.RemoveWall(0);
                        currentNodes[currentNodes.Count - 1].RemoveWall(1);
                        break;
                    //remove upper walls
                    case 3:
                        chosennode.RemoveWall(3);
                        currentNodes[currentNodes.Count - 1].RemoveWall(2);
                        break;
                    //remove lowers walls
                    case 4:
                        chosennode.RemoveWall(2);
                        currentNodes[currentNodes.Count - 1].RemoveWall(3);
                        break;
                }

                currentNodes.Add(chosennode);
            }
            else
            {
                //this backtracks the current node and sets the current nodes that have been completed to completed
                completed.Add(currentNodes[currentNodes.Count - 1]);
                currentNodes.RemoveAt(currentNodes.Count - 1);
            }
        }
    }

    public void SetSizeX(int aSize)
    {
        size.x = aSize;
    }
    public void SetSizeY(int aSize)
    {
        size.y = aSize;
    }
    public int GetsizeX()
    {
        return size.x;
    }
    public int GetsizeY()
    {
        return size.y;
    }
}
