using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weekplatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private float weakheight = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        Transform t = collision.gameObject.transform;
        weakheight = t.position.y;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("MainCamera")){
            rb.gravityScale = 0f;
            gameObject.SetActive(false);
        }
        Transform t = collision.gameObject.transform;
        if(weakheight > t.position.y){
            if(GetComponent<Animator>() != null){
                //Play animation
                //Destroy the platform
                GetComponent<Animator>().SetTrigger("Trigger");
                Invoke("HideGameObject", 0.2f);
            }
        }
    }

    void HideGameObject(){
        rb.gravityScale = 2f;
    }
}
