using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float bounceSpeed = 4f;
    
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.contacts[0].normal == Vector2.down){
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if(rb != null){
                rb.velocity = Vector2.up * bounceSpeed;
            }
            if(GetComponent<Animator>() != null){
                GetComponent<Animator>().SetTrigger("Trigger");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("MainCamera")){
            gameObject.SetActive(false);
        }
    }
}
