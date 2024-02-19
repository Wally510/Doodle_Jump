using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D collision) {
        GameObject Doodler = GameObject.FindGameObjectWithTag("Player");
        GameObject Bullet = GameObject.FindGameObjectWithTag("bullet");
        if(Doodler == collision.gameObject){
            if(Doodler.GetComponent<Doodler>().dead == 0){
                Doodler.GetComponent<Doodler>().dead = 2;
            }
        }else if(Bullet == collision.gameObject){
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("MainCamera")){
            gameObject.SetActive(false);
        }
    }
}
