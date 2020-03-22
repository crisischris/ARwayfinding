using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonClick : MonoBehaviour
{

    public GameObject location;
    public bool right;
    public bool left;
    public string destination;


    void Start()
    {
        destination = null;
    }
    

    public void moveUp()
    {
        location.transform.position = new Vector3(location.transform.position.x, location.transform.position.y + .1f, location.transform.position.z);
    }

    public void moveDown()
    {
        location.transform.position = new Vector3(location.transform.position.x, location.transform.position.y - .1f, location.transform.position.z);
    }


    public void rotateRight()
    {
        location.transform.Rotate(location.transform.rotation.x, location.transform.rotation.y + 1, location.transform.rotation.z);
    }

    public void rotateLeft()
    {
        location.transform.Rotate(location.transform.rotation.x, location.transform.rotation.y - 1, location.transform.rotation.z);
    }

    public void assignKitchen()
    {
        destination = "DESTINATION - KITCHEN";
    }

    public void assingBedroom()
    {
        destination = "DESTINATION - MASTER";
    }

    public void setDestination()
    {
        destination = null;
    }
}
