using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doodler : MonoBehaviour
{
    public int dead = 0;
    private int flag=0;
    public Vector3 direction;
    public GameObject bullet;
    public Transform bulletPos;
    private float timefly = 0;
    public int fly = 0;
    public Transform flyhat;
    public Transform flyrocket;
    public Transform Shoot;
    public float moveSpeed;
    Rigidbody2D rb;

    void getdirection(){
        Vector3 directions = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if(directions.y < 0){
            directions.y = -directions.y;
        }
        direction.x = directions.x;
        direction.y = directions.y;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {
        /* Vector2  dir = Vector2.zero;//方块移动向量
 
        dir.x = Input.acceleration.x;
        dir.y = -0.01f;
 
        transform.Translate(dir * moveSpeed * Time.deltaTime); */

        /* float h = Input.acceleration.x; */
        float h = Input.GetAxis("Horizontal");
        if(fly == 0 && dead == 0){
            rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);
            if (Input.GetMouseButtonDown(0) && flag == 0){
                flag=1;
                Shootgame();
            }
            if(flag == 0){
                Trun(h);
            }
        }else if(fly == 1 && dead == 0){
            rb.isKinematic = true;
            rb.velocity = new Vector2(h * moveSpeed, 8);
            flyhat.gameObject.SetActive(true);
            timefly += Time.deltaTime;
            if(timefly >= 5){
                rb.isKinematic = false;
                timefly = 0;
                fly = 0;
                flyhat.gameObject.SetActive(false);
            }
            Trun(h);
        }else if(fly == 2 && dead == 0){
            rb.isKinematic = true;
            rb.velocity = new Vector2(h * moveSpeed, 11);
            flyrocket.gameObject.SetActive(true);
            timefly += Time.deltaTime;
            if(timefly >= 5){
                rb.isKinematic = false;
                timefly = 0;
                fly = 0;
                flyrocket.gameObject.SetActive(false);
            }
            Trun(h);
        }

        if(dead > 0){
            rb.isKinematic = true;
            if(dead == 1){
                rb.velocity = new Vector2(h * moveSpeed, -8);
                Trun(h);
            }
            if(dead == 2){
                timefly += Time.deltaTime;
                if(timefly >= 0.3){
                    rb.velocity = new Vector2(h * moveSpeed, 11 - 15 * timefly);
                }else{
                    rb.velocity = new Vector2(h * moveSpeed, 0);
                }
            }
        }
    }
    void Trun(float h){
        if(h < 0){
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(h > 0){
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void Shootgame(){
        getdirection();
        Shoot.gameObject.SetActive(true);
        GetComponent<Animator>().SetTrigger("shoot");
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        Invoke("Shootback", 0.4f);
    }
    void Shootback(){
        Shoot.gameObject.SetActive(false);
        GetComponent<Animator>().SetTrigger("back");
        flag = 0;
    }
}
