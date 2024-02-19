using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /* // 获取鼠标位置相对移动向量
        Vector2 translation = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        // 根据鼠标位置相对移动向量移动物体
        transform.Translate(translation * speed * Time.deltaTime); */
        // 当鼠标左键按下时
        if (Input.GetMouseButton(0))
        {
            // 鼠标坐标默认是屏幕坐标，首先要转换到世界坐标
            // 物体坐标默认就是世界坐标
            // 两者取差得到方向向量
            Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            // 方向向量转换为角度值
            float angle =360-Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            if(angle > 450){
                angle = 900-angle;
            }else if(angle < 270){
                angle = 540-angle;
            }
            // 将当前物体的角度设置为对应角度
            transform.eulerAngles = new Vector3(0, 0, angle);
        }

    }
}
