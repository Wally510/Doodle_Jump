using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopstart : MonoBehaviour
{
    public GameObject stop;
    public GameObject start;
    public GameObject gamestop;
    public Transform background_black;
    public void stopclick(){
        stop.SetActive(false);
        start.SetActive(true);
        gamestop.SetActive(true);
        background_black.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void startclick(){
        stop.SetActive(true);
        start.SetActive(false);
        gamestop.SetActive(false);
        background_black.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
