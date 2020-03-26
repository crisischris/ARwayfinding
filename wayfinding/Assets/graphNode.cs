using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graphNode : MonoBehaviour
{
    public node[] graph;
    public GameObject user;
    public float curMin = 10000;
    public float dist;
    public GameObject curObject;
    public GameObject closestNode;
    public GameObject interaction;
    public GameObject destination;
    public string desinationName;
    public List<GameObject> path = new List<GameObject>();
    public List<GameObject> dfs = new List<GameObject>();
    public Queue<GameObject> bfs = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        LineRenderer lr = user.GetComponent<LineRenderer>();
        lr.startWidth = .1f;
        lr.endWidth = .1f;

        turnOffNodes();
    }

    // Update is called once per frame
    void Update()
    {
        curMin = 100000;



        //find the nearst node
        for (int i = 0; i < graph.Length; i++)
        {
            curObject = graph[i].gameObject;
            //dist = curObject.GetComponent<node>().dist;
            dist = curObject.GetComponent<node>().dist;
            if (dist < curMin)
            {
                closestNode = curObject;
                curMin = dist;
            }
        }


        //add objects to lineRenderer vertext list
        Vector3[] lrPos = new Vector3[path.Count];

        for (int i = 0; i < path.Count; i++)
        {
            lrPos[i] = path[i].transform.position;
        }

        LineRenderer lr = user.GetComponent<LineRenderer>();
        lr.positionCount = lrPos.Length;
        lr.SetPositions(lrPos);

        // detect button click on 
        desinationName = interaction.GetComponent<buttonClick>().destination;
        if (desinationName != null)
        {
            for (int i = 0; i < graph.Length; i++)
                if (graph[i].GetComponent<node>().name == desinationName)
                    destination = graph[i].gameObject;

            //set the original path
            traverse(destination);

            //reset the string
            interaction.GetComponent<buttonClick>().setDestination();
            interaction.GetComponent<buttonClick>().hideUI();
        }


    }

    void traverse(GameObject destination)
    {
        //clear the path
        path.Clear();
        bfs.Clear();

        turnOffNodes();

        //starting node
        bfs.Enqueue(closestNode);
        GameObject top = null;

        //if closest node is destination, no traversal need
        if (closestNode == destination)
        {
            closestNode.GetComponent<MeshRenderer>().enabled = true;
            path.Add(closestNode);
        }
        else
        {
            while (bfs.Count > 0)
            {
                top = bfs.Dequeue();
                top.GetComponent<node>().visited = true;

                if (top == destination)
                    break;

                for (int i = 0; i < top.GetComponent<node>().neighbers.Length; i++)
                {
                    if (top.GetComponent<node>().neighbers[i].visited == false)
                    {
                        top.GetComponent<node>().neighbers[i].parent = top;
                        bfs.Enqueue(top.GetComponent<node>().neighbers[i].gameObject);
                    }
                }

            }

            //trace back the path and turn on the node mesh
            while (top != null)
            {
                top.GetComponent<MeshRenderer>().enabled = true;
                path.Add(top);
                top = top.GetComponent<node>().parent;
            }

        }

        //reset the nodes
        resetNodes();
    }

    void resetNodes()
    {
        for(int i = 0; i < graph.Length; i++)
        {
            graph[i].visited = false;
            graph[i].parent = null;
        }
    }

    void turnOffNodes()
    {
        //turn off mesh renderer of nodes
        for (int i = 0; i < graph.Length; i++)
        {
            graph[i].GetComponent<MeshRenderer>().enabled = false;
        }
    }
       
}
