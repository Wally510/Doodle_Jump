using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fraction : MonoBehaviour
{
    public Transform objA;
    public Text fa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int f = objA.gameObject.GetComponent<CameraFollow>().fraction;   
        int die = objA.gameObject.GetComponent<CameraFollow>().die;  
        if(die == 0){
            fa.text = f.ToString();
        } 
    }
}
