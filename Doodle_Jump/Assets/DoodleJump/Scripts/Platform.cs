using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Rigidbody2D rb;
    public PlatformType platformType;
    public float bounceSpeed = 4f;
    private float weakheight = 0f;
    public GameObject weekb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(platformType == PlatformType.weak){
            int weekf = weekb.gameObject.GetComponent<weekbox>().weekf;
            if(weekf == 1){
                if(GetComponent<Animator>() != null){
                    //Play animation
                    //Destroy the platform
                    weekb.gameObject.GetComponent<weekbox>().weekf = 0;
                    GetComponent<Animator>().SetTrigger("Trigger");
                    rb.gravityScale = 1.5f;
                }
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.contacts[0].normal == Vector2.down){
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if(rb != null){
                rb.velocity = Vector2.up * bounceSpeed;
            }

            //Week Platform
            /* if(platformType == PlatformType.weak){
                if(GetComponent<Animator>() != null){
                    //Play animation
                    //Destroy the platform
                    GetComponent<Animator>().SetTrigger("Trigger");
                    Invoke("HideGameObject", 0.4f);
                }
            } */
        }
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        Transform t = collision.gameObject.transform;
        if(platformType == PlatformType.weak){
            weakheight = t.position.y;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("MainCamera")){
            if(platformType == PlatformType.weak){
                rb.gravityScale = 0f;
            }
            gameObject.SetActive(false);
        }
        /* Transform t = collision.gameObject.transform;
        if(platformType == PlatformType.weak){
            if(weakheight > t.position.y){
                if(GetComponent<Animator>() != null){
                    //Play animation
                    //Destroy the platform
                    GetComponent<Animator>().SetTrigger("Trigger");
                    Invoke("HideGameObject", 0.3f);
                }
            }
        } */
    }

    void HideGameObject(){
        rb.gravityScale = 1.5f;
    }
}

public enum PlatformType{
    normal,weak
}
