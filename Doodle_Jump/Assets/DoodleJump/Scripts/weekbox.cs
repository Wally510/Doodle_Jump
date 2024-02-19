using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weekbox : MonoBehaviour
{
    private float weakheight = 0f;
    public int weekf = 0;
    // Start is called before the first frame update
    void Start()
    {
        weekf = 0;
    }
    private void OnTriggerEnter2D (Collider2D collision) {
        Transform t = collision.gameObject.transform;
        weakheight = t.position.y;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        GameObject player = GameObject.FindWithTag("Player");
        Transform t = collision.gameObject.transform;
        if(collision.gameObject == player){
            if(weakheight > t.position.y){
                weekf = 1;
            }
        }
    }
}
