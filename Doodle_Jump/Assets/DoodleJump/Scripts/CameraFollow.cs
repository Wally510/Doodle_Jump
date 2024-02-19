using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public int die = 0;
    public Transform game_over;
    public Transform background_black;
    public GameObject fraction_over;
    private float diefly = 0;
    public int fraction;
    public Transform target;
    public float smoothSpeed = 0.3f;
    Vector3 speed;

    void Start(){
        fraction=0;
    }
    void Update(){
        if(die == 0){
            fraction= (int)transform.position.y;
        }
        if(die == 1){
            diefly += Time.deltaTime;
            if(diefly < 1.5f){
                Vector3 targetPos = new Vector3(0f, target.position.y, -10f);
                transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref speed, smoothSpeed *Time.deltaTime);
            }else{
                game_over.gameObject.SetActive(true);
                background_black.gameObject.SetActive(true);
                fraction_over.SetActive(true);
                /* Invoke("gameover", 1.2f); */
            }
        }
    }

    private void LateUpdate() {
        if(target.position.y > transform.position.y){
            Vector3 targetPos = new Vector3(0f, target.position.y, -10f);
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref speed, smoothSpeed *Time.deltaTime);
        }
        else if(target.position.y < transform.position.y - 5.0f){
            /* Application.LoadLevel("Start"); */
            GameObject Doodler = GameObject.FindGameObjectWithTag("Player");
            if(Doodler.GetComponent<Doodler>().dead == 0){
                Doodler.GetComponent<Doodler>().dead = 1;
                die = 1;
            }else{
                game_over.gameObject.SetActive(true);
                background_black.gameObject.SetActive(true);
                fraction_over.SetActive(true);
                /* Invoke("gameover", 1.2f); */
            }
        }
    }

    [System.Obsolete]
    void gameover(){
        Application.LoadLevel("Start");
    }
}
