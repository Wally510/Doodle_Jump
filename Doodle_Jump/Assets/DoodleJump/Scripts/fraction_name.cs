using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class fraction_name : MonoBehaviour
{
    public Text fa;
    public Text fb;
    // Start is called before the first frame update
    void Start()
    {
        fa.text = fb.text;
        DateTime NowTime = DateTime.Now.ToLocalTime();
        string name = "new player";
        if(LocalConfig.LoadUserData(name) == null){
            UserData userData = LocalConfig.LoadUserData(name);
            userData = new UserData();
            userData.username = "new player";
            userData.maxfaction = fa.text + '#';
            userData.nowtime = NowTime.ToString() + '#';
            Debug.Log(NowTime.ToString());
            LocalConfig.SaveUserData(userData);
        }else{
            UserData userData = LocalConfig.LoadUserData(name);
            userData.maxfaction = userData.maxfaction + fa.text + '#';
            userData.nowtime = userData.nowtime + NowTime.ToString() + '#';
            LocalConfig.SaveUserData(userData);
        }
        /* My.maxfaction.Enqueue(int.Parse(fa.text));
        My.nowtime.Enqueue(NowTime); */
    }
}
