using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canva_camera : MonoBehaviour
{
    public RectTransform panel;
    public Image top;
    public Image down;
    public Image left;
    public Image rank_menu;
    public RectTransform menu;
    // Start is called before the first frame update
    void Start()
    {
        top.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.width * 0.375f);
        top.rectTransform.localPosition = new Vector3(0,(Screen.height-Screen.width * 0.375f)/2,0);

        down.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.width * 0.5f);
        down.rectTransform.localPosition = new Vector3(0,-(Screen.height-Screen.width * 0.5f)/2,0);

        float leftheight = Screen.height-Screen.width * 0.375f-Screen.width * 0.5f;
        left.rectTransform.sizeDelta = new Vector2(Screen.width * 0.18f, leftheight);
        left.rectTransform.localPosition = new Vector3(-(Screen.width-Screen.width * 0.18f)/2,Screen.height/2-Screen.width * 0.375f-leftheight/2,0);

        float rankwidth = Screen.width - Screen.width * 0.15f;
        rank_menu.rectTransform.sizeDelta = new Vector2(rankwidth, rankwidth * 0.17f);
        rank_menu.rectTransform.localPosition = new Vector3((Screen.width-rankwidth)/2,Screen.height/2-Screen.width * 0.33f-rankwidth * 0.17f/2,0);

        panel.offsetMin = new Vector2(Screen.width * 0.15f, Screen.width * 0.45f);
        panel.offsetMax = new Vector2(0, -(Screen.width * 0.33f+rankwidth * 0.17f));

        menu.sizeDelta = new Vector2(Screen.width * 0.33f, Screen.width * 0.14f);
        menu.localPosition = new Vector3(Screen.width * 0.17f,Screen.width * 0.2f-Screen.height/2,0);
        menu.GetChild(0).GetComponent<Text>().fontSize = (int)(Screen.width * 0.06f);
        //Vector2 newResolution = new Vector2(Screen.height, Screen.width);
        //GetComponent<CanvasScaler>().referenceResolution = newResolution;
        //GetComponent<CanvasScaler>().referenceResolution.y = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
