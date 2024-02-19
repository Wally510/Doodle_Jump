using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Content : MonoBehaviour
{
    public RectTransform image1;
    public RectTransform image2;
    public RectTransform cont;
    // Start is called before the first frame update
    void Start()
    {
        cont.sizeDelta = new Vector2(Screen.width - Screen.width * 0.15f, Screen.height);
        //image.sizeDelta = new Vector2(Screen.width - Screen.width * 0.15f, (Screen.width - Screen.width * 0.15f) * 0.17f);

        string name = "new player";
        UserData userData = LocalConfig.LoadUserData(name);
        int l = 0;
        if(userData != null){
            for(int j=0;j<userData.maxfaction.Length;j++){
                if(userData.maxfaction[j] == '#'){
                    l++;
                }
            }
        }
        Debug.Log(l);
        int[] mf = new int[l];
        string[] dt = new string[l];
        int i = 0;
        int lf = l;
        string mff = "";
        string dtt = "";
        if(l!=0){
            i = 0;
            for(int j=0;j<userData.maxfaction.Length;j++){
                if(userData.maxfaction[j] == '#'){
                    mf[i]=int.Parse(mff);
                    mff="";
                    i++;
                }else{
                    mff = mff+userData.maxfaction[j];
                }
            }
            i = 0;
            for(int j=0;j<userData.nowtime.Length;j++){
                if(userData.nowtime[j] == '#'){
                    Debug.Log(dtt);
                    dt[i]=dtt;
                    dtt="";
                    i++;
                }else{
                    dtt = dtt+userData.nowtime[j];
                }
            }
        }
        for(i = 1;i < l;i++){
            for(int j = i;j >= 1;j--){
                if(mf[j] > mf[j-1]){
                    int m = mf[j];
                    mf[j] = mf[j-1];
                    mf[j-1] = m;
                    string d = dt[j];
                    dt[j] = dt[j-1];
                    dt[j-1] = d;
                }else{
                    break;
                }
            }
        }
        if(l > 0){
            cont.sizeDelta = new Vector2(Screen.width - Screen.width * 0.15f, (Screen.width - Screen.width * 0.15f) * 0.18f * l);
        }
        if(l!=0){
            userData.maxfaction = "";
            userData.nowtime = "";
        }
        for(i = 0;i < l;i++){
            userData.maxfaction = userData.maxfaction + mf[i].ToString() + '#';
            userData.nowtime = userData.nowtime + dt[i] + '#';
        }
        if(l!=0){
            LocalConfig.SaveUserData(userData);
        }
        for(i = 0;i < l;i++){
            RectTransform image;
            if(i % 2 == 0){
                image = image2;
            }else{
                image = image1;
            }
            Instantiate(image, cont);
            float contwidth = Screen.width - Screen.width * 0.15f;
            cont.GetChild(i).GetComponent<RectTransform>().sizeDelta = new Vector2(contwidth, contwidth * 0.17f);
            cont.GetChild(i).GetComponent<RectTransform>().localPosition = new Vector3(0,-(i * contwidth * 0.17f + (i+1) * contwidth * 0.005f),0);

            cont.GetChild(i).GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(contwidth * 0.08f, contwidth * 0.17f);
            float y = cont.GetChild(i).GetChild(0).GetComponent<RectTransform>().localPosition.y;
            cont.GetChild(i).GetChild(0).GetComponent<RectTransform>().localPosition = new Vector3(contwidth * 0.04f - contwidth,y,0);
            cont.GetChild(i).GetChild(0).GetComponent<Text>().fontSize = (int)(contwidth *0.07f);

            cont.GetChild(i).GetChild(1).GetComponent<Text>().text = "new player";
            cont.GetChild(i).GetChild(1).GetComponent<RectTransform>().sizeDelta = new Vector2(contwidth * 0.35f, contwidth * 0.17f);
            cont.GetChild(i).GetChild(1).GetComponent<RectTransform>().localPosition = new Vector3(contwidth * -0.745f,y,0);
            cont.GetChild(i).GetChild(1).GetComponent<Text>().fontSize = (int)(contwidth *0.07f);

            cont.GetChild(i).GetChild(2).GetComponent<Text>().text = mf[i].ToString();
            cont.GetChild(i).GetChild(2).GetComponent<RectTransform>().sizeDelta = new Vector2(contwidth * 0.525f, contwidth * 0.12f);
            cont.GetChild(i).GetChild(2).GetComponent<RectTransform>().localPosition = new Vector3(contwidth * -0.3125f,y + contwidth * 0.02f,0);
            cont.GetChild(i).GetChild(2).GetComponent<Text>().fontSize = (int)(contwidth *0.07f);

            cont.GetChild(i).GetChild(3).GetComponent<Text>().text = dt[i].ToString();
            cont.GetChild(i).GetChild(3).GetComponent<RectTransform>().sizeDelta = new Vector2(contwidth * 0.525f, contwidth * 0.06f);
            cont.GetChild(i).GetChild(3).GetComponent<RectTransform>().localPosition = new Vector3(contwidth * -0.3125f,y + contwidth * -0.04f,0);
            cont.GetChild(i).GetChild(3).GetComponent<Text>().fontSize = (int)(contwidth *0.05f);

            cont.GetChild(i).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
