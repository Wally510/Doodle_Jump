using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float mywidth;
    private float move = 0f;
    private int f = 0;
    void Start(){
        Camera mainCamera = Camera.main;
        float screenWidth = Screen.width;
        mywidth = screenWidth / mainCamera.pixelWidth * mainCamera.orthographicSize / 2;
        mywidth = Random.Range(mywidth/2f, mywidth);
    }
    // Update is called once per frame
    void Update()
    {
        if(f == 0 && move < mywidth){
            move += 1.5f*Time.deltaTime;
            transform.Translate(1.5f*Time.deltaTime,0,0);
        }else{
            f = 1;
        }
        if(f == 1 && move > 0f){
            move -= 1.5f*Time.deltaTime;
            transform.Translate(-1.5f*Time.deltaTime,0,0);
        }else{
            f = 0;
        }
    }
}
