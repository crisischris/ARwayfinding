using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class buttonArragement : MonoBehaviour
{
    public Button displayUp;

    // set all the buttons
    void Awake()
    {
        //main UI display up button
        displayUp.transform.position = new Vector3(Screen.width / 2, displayUp.GetComponent<RectTransform>().sizeDelta.y / 2, 0); 


    }

}
