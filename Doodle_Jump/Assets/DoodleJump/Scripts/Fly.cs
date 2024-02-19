using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public PlatformFly platformFly;
    private void OnTriggerEnter2D (Collider2D collision) {
        GameObject Doodler = GameObject.FindGameObjectWithTag("Player");
        if(Doodler == collision.gameObject){
            if(platformFly == PlatformFly.hat && Doodler.GetComponent<Doodler>().fly == 0){
                Doodler.GetComponent<Doodler>().fly = 1;
                gameObject.SetActive(false);
            }else if(platformFly == PlatformFly.rocket && Doodler.GetComponent<Doodler>().fly == 0){
                Doodler.GetComponent<Doodler>().fly = 2;
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("MainCamera")){
            gameObject.SetActive(false);
        }
    }
}

public enum PlatformFly{
    hat,rocket
}
