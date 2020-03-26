using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class node : MonoBehaviour
{
   
    public node next;
    public node[] neighbers;
    public string name;
    public bool visited = false;
    public GameObject parent;

    public GameObject user;
    public float dist;
    
    // Start is called before the first frame update
    void Start()
    {
        next = null;
        parent = null;
    }

    void Update()
    {
        dist = Vector3.Distance(user.transform.position, gameObject.transform.position);
    }
}
