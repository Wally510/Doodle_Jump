using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private int fdx = 1;
    private float dx;
    private float dy;
    public Vector3 direction;
    public float speed;
    Rigidbody2D shootbullet;
    // Start is called before the first frame update
    void Start()
    {
        shootbullet = GetComponent<Rigidbody2D>();
        GameObject Doodler = GameObject.FindGameObjectWithTag("Player");
        direction = Doodler.GetComponent<Doodler>().direction;
        if(direction.x < 0){
            fdx = -1;
        }
        float x_y = Mathf.Pow(direction.y, 2)/Mathf.Pow(direction.x, 2);
        dx = Mathf.Sqrt(4f/(1+x_y));
        dy = Mathf.Sqrt(Mathf.Pow(dx,2)*x_y);
    }

    // Update is called once per frame
    void Update()
    {
        shootbullet.velocity = new Vector2(dx * fdx * speed, dy * speed);
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("MainCamera")){
            /* gameObject.SetActive(false); */
            Destroy(gameObject);
        }
    }
}
