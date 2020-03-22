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
                
            //curObject.SetActive(false);
        }

        //closestNode.SetActive(true);

        //add objects to lineRenderer vertext list
        Vector3[] lrPos = new Vector3[path.Count];
        //Debug.Log(lrPos.Length);

        for (int i = 0; i < path.Count; i++)
        {
            lrPos[i] = path[i].transform.position;
        }

        LineRenderer lr = user.GetComponent<LineRenderer>();
        lr.positionCount = lrPos.Length;
        lr.SetPositions(lrPos);

        //Debug.Log(closestNode.GetComponent<node>().name);

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
        }


    }

    void traverse(GameObject destination)
    {
        //clear the path
        path.Clear();
        dfs.Clear();

        turnOffNodes();

        //starting node
        dfs.Add(closestNode);
        
        while(dfs.Count > 0)
        {
                Debug.Log("in loop");
                //if(dfs.Peek() == currNode)
                GameObject topNode = dfs[dfs.Count - 1];
                topNode.GetComponent<node>().visited = true;

                if (topNode == destination)
                    break;

                for (int i = 0; i < topNode.GetComponent<node>().neighbers.Length; i++)
                {
                    if (topNode.GetComponent<node>().neighbers[i].visited == false)
                    {
                        dfs.Add(topNode.GetComponent<node>().neighbers[i].gameObject);
                    }
                }

                //didn't add any
                if (dfs[dfs.Count - 1] == topNode)
                {
                    dfs.RemoveAt(dfs.Count - 1);
                }

        }

        for(int i = 0; i < dfs.Count; i++)
        {
            if(dfs[i].GetComponent<node>().visited)
            {
                dfs[i].GetComponent<MeshRenderer>().enabled = true;
                path.Add(dfs[i]);
            }
        }

        //reset the nodes
        resetVisited();
    }

    void resetVisited()
    {
        for(int i = 0; i < graph.Length; i++)
        {
            graph[i].visited = false;
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
