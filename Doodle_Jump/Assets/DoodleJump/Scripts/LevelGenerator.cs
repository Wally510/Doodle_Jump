using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private int flag = 0;
    public Transform objA;
    public GameObject[] platformPrefabs;
    float currentYPos = -5f;
    public float cameraHeight = 5.0f;
    private float mywidth;

    public Transform platformPool;
    public Transform platformMove;
    public Transform platformWeak;
    public Transform platformSpring;
    public Transform platformflyhat;
    public Transform platformmonster;
    // Start is called before the first frame update
    void Start()
    {
        Camera mainCamera = Camera.main;
        float screenWidth = Screen.width;
        mywidth = screenWidth / mainCamera.pixelWidth * mainCamera.orthographicSize / 2;
        SpawnPlatformPool();

        while(currentYPos < Camera.main.transform.position.y + cameraHeight){
            PickNewPlatform();
        }
    }


    void SpawnPlatformPool(){
        int basicPlatformAmount = 30;
        int movePlatformAmount = 10;
        int weakPlatformAmount = 15;
        int springPlatformAmount = 10;

        for(int i = 0; i < basicPlatformAmount; i++) {
            GameObject platform = Instantiate(platformPrefabs[0], platformPool);
            platform.SetActive(false);
        }

        for(int i = 0; i < weakPlatformAmount; i++) {
            GameObject platform = Instantiate(platformPrefabs[1], platformWeak);
            platform.SetActive(false);
        }
        for(int i = 0; i < springPlatformAmount; i++) {
            GameObject platform = Instantiate(platformPrefabs[2], platformSpring);
            platform.SetActive(false);
        }
        for(int i = 0; i < movePlatformAmount; i++) {
            GameObject platform = Instantiate(platformPrefabs[3], platformMove);
            platform.SetActive(false);
        }
        for(int i = 0; i < 1; i++) {
            GameObject platform = Instantiate(platformPrefabs[4], platformflyhat);
            platform.SetActive(false);
        }
        for(int i = 0; i < 1; i++) {
            GameObject platform = Instantiate(platformPrefabs[5], platformflyhat);
            platform.SetActive(false);
        }
        for(int i = 0; i < 1; i++) {
            GameObject platform = Instantiate(platformPrefabs[6], platformmonster);
            platform.SetActive(false);
        }
    }

    void Generate(int r,float x,Transform transform){
        do{
            r = Random.Range(0, transform.childCount);
        }while(transform.GetChild(r).gameObject.activeInHierarchy);
        transform.GetChild(r).position = new Vector2(x, currentYPos);
        transform.GetChild(r).gameObject.SetActive(true);
    }    
    void PickNewPlatform(){
        currentYPos += Random.Range(0.3f, 1f);
        float xPos = Random.Range(-mywidth/1.2f, mywidth/1.2f);
        int move = Random.Range(-1, 15);
        int spring = Random.Range(-1, 10);
        int weak = Random.Range(-1,5);
        int r = 0;
        if(flag > 100){
            weak = Random.Range(-1,8);
            spring = Random.Range(-1, 8);
            currentYPos += Random.Range(0, 0.2f);
        }else if(flag > 300){
            weak = Random.Range(-1,10);
            spring = Random.Range(-1, 6);
            currentYPos += Random.Range(0.2f, 0.5f);
        }
        if(weak < 0){
            Generate(r,xPos,platformWeak);
        }else{
            if(flag > 30){
                if(move < 0){
                    float movewidth = platformMove.GetChild(r).gameObject.GetComponent<Move>().mywidth;
                    float xMove = Random.Range(-mywidth/1.2f, (mywidth-movewidth)/2f);
                    Generate(r,xMove,platformMove);
                }else{
                    Generate(r,xPos,platformPool);
                }
            }else{
                Generate(r,xPos,platformPool);
            }
        }

        if(spring < 0 && weak >= 0 && move >= 0){
            int monster = 0;
            int fly = Random.Range(-1, 15);
            int rr = 0;
            float xspring = Random.Range(-0.4f, 0.4f);
            if(flag > 100){
                fly = Random.Range(-1, 10);
                monster = Random.Range(-1, 10);
            }else if(flag > 300){
                fly = Random.Range(-2, 5);
                monster = Random.Range(-2, 5);
            }
            if(fly < 0){
                int hatrocket = Random.Range(-1, 1);
                if(hatrocket < 0 && monster <= 0){
                    if(!platformflyhat.GetChild(1).gameObject.activeInHierarchy){
                        platformflyhat.GetChild(1).position = new Vector2(xPos + xspring, currentYPos + 0.12f);
                        platformflyhat.GetChild(1).gameObject.SetActive(true);
                    }
                }else if(hatrocket >= 0 && monster <= 0){
                    if(!platformflyhat.GetChild(0).gameObject.activeInHierarchy){
                        platformflyhat.GetChild(0).position = new Vector2(xPos + xspring, currentYPos + 0.12f);
                        platformflyhat.GetChild(0).gameObject.SetActive(true);
                    }
                }else{
                    if(!platformmonster.GetChild(0).gameObject.activeInHierarchy){
                        platformmonster.GetChild(0).position = new Vector2(xPos + xspring, currentYPos + 0.12f);
                        platformmonster.GetChild(0).gameObject.SetActive(true);
                    }
                }
            }else{
                do{
                    rr = Random.Range(0, platformSpring.childCount);
                }while(platformSpring.GetChild(rr).gameObject.activeInHierarchy);
                platformSpring.GetChild(rr).position = new Vector2(xPos + xspring, currentYPos + 0.12f);
                platformSpring.GetChild(rr).gameObject.SetActive(true);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        flag = objA.gameObject.GetComponent<CameraFollow>().fraction;  
        if(currentYPos < Camera.main.transform.position.y + cameraHeight){
            PickNewPlatform();
        }
    }
}
