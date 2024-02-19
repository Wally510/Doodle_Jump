using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSide : MonoBehaviour
{
    public Transform doodler;
    void Start() {
        Camera mainCamera = Camera.main;
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        float screenWidth = Screen.width;
        float screenHight = Screen.height;
        boxCollider2D.size = new Vector2(screenWidth / mainCamera.pixelWidth * mainCamera.orthographicSize, screenHight / mainCamera.pixelHeight * mainCamera.orthographicSize * 2);    
    }
    private void OnTriggerExit2D(Collider2D collision) {
        Transform t = collision.gameObject.transform;
        if(doodler == t){
            if(t.position.y > transform.position.y - 4.5f){
                t.position = new Vector3((-t.position.x)/1f,t.position.y,0f);
            }
        }
    }
}
