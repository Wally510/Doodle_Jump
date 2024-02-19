using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class over_again : MonoBehaviour
{
    public void again () {
        SceneManager.LoadScene(2);
        Time.timeScale=1;
        return;
    }

    [System.Obsolete]
    public void menu () {
        Application.LoadLevel("Start");
    }
}
