using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class buttonClick : MonoBehaviour
{

    public GameObject location;
    public bool right;
    public bool left;
    public string destination;
    public Camera userPos;
    public List<string> posArr = new List<string>();
    public Text output;
    public GameObject Uinterface;
    public bool lerpUIUp;
    public bool lerpUIDown;

    private Vector2 upStartPos;
    private Button up;

    void Start()
    {
        userPos = FindObjectOfType<Camera>();
        destination = null;
        up = GameObject.FindObjectOfType<Canvas>().GetComponent<buttonArragement>().displayUp;
        upStartPos = up.transform.position;
    }
    
    void Update()
    {
        output.text = null;

        foreach(String s in posArr)
        {
            output.text += s + "\n";   
        }

        //raise the UI up and send the displayUp button down
        if(lerpUIUp)
        {
            Uinterface.transform.position = Vector2.Lerp(Uinterface.transform.position, new Vector2(Uinterface.transform.position.x, Screen.height / 2 - 200 ), Time.deltaTime * 10);
            up.transform.position = Vector2.Lerp(up.transform.position, new Vector2(upStartPos.x, upStartPos.y - up.GetComponent<RectTransform>().sizeDelta.y * 2), Time.deltaTime * 5);
        }

        //send the UI back down, bring the displayUp button back
        if (lerpUIDown)
        {
            Uinterface.transform.position = Vector3.Lerp(Uinterface.transform.position, new Vector2(Uinterface.transform.position.x, -50), Time.deltaTime * 10);
            up.transform.position = Vector2.Lerp(up.transform.position, upStartPos, Time.deltaTime * 10);

        }
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

    public void displayUI()
    {
        lerpUIDown = false;
        lerpUIUp = true;
    }

    public void hideUI()
    {
        lerpUIDown = true;
        lerpUIUp = false;
        posArr.Clear();
    }

    public void assignKitchen()
    {
        destination = "DESTINATION - KITCHEN";
    }

    public void assignBedroom()
    {
        destination = "DESTINATION - MASTER";
    }

    public void assignOutside()
    {
        destination = "DESTINATION - OUTSIDE";
    }

    public void logPos()
    {
        Vector3 curPos = userPos.transform.position;
        posArr.Add(curPos.ToString()); 
    }

    public void setDestination()
    {
        destination = null;
    }


}
