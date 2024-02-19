using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gamestop : MonoBehaviour
{
    public GameObject stop;
    public GameObject start;
    public GameObject games;
    public Transform background_black;

    public void back(){
        SceneManager.LoadScene(2);
        Time.timeScale=1;
        return;
    }
    
    public void star () {

        stop.SetActive(true);
        start.SetActive(false);
        games.SetActive(false);
        background_black.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    [System.Obsolete]
    public void home(){
        Application.LoadLevel("Start");
    }
}
