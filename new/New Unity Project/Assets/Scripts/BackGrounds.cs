using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGrounds : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] backGrounds; //定义数组
    public float fparallax = 0.4f; // 不加f 则0.4为double
    public float layerFraction = 5f;
    public float fSmooth = 5f;
    Transform cam;
    Vector3 previousCamPos;//存上一帧位置
    private void Awake()
    {
        cam = Camera.main.transform;

    }
    private void Start()
    {
        previousCamPos = cam.position;
    }

    // Update is called once per frame
    void Update()
    {
        float fParallaxX = (previousCamPos.x - cam.position.x) * fparallax;
        for(int i = 0; i < backGrounds.Length; i++)
        {
            float fNewX = backGrounds[i].position.x 
                + fParallaxX * (1 + layerFraction * i);
            Vector3 newPos = new Vector3(fNewX, backGrounds[i].position.y, backGrounds[i].position.z);
            backGrounds[i].position = Vector3.Lerp(backGrounds[i].position, newPos, fSmooth * Time.deltaTime);
            //初始位置，移动后位置，Time.deltatime时间间隔
        }
        previousCamPos = cam.position;
    }
}
