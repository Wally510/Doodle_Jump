using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playclick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [System.Obsolete]
    public void Click()
    {
 
        Debug.Log("click");
        Time.timeScale = 1;
        Application.LoadLevelAsync("Game");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
