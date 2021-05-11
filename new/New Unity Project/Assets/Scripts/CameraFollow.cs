using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTran; //主角的Transform
    public float maxDistanceX = 2;
    public float maxDistanceY = 2;
    public float xSpeed = 4;
    public float ySpeed = 4;
    public Vector2 maxXandY;
    public Vector2 minXandY = new Vector2(-8, 8);

    // Start is called before the first frame update
    private bool NeedMoveX()
    {
        bool bMove = false;
        if (Mathf.Abs(transform.position.x - playerTran.position.x) > maxDistanceX)
            bMove = true;
        else
            bMove = false;
        return bMove;
    }
    private bool NeedMoveY()
    {
        bool bMove = false;
        if (Mathf.Abs(transform.position.x - playerTran.position.x) > maxDistanceX)
            bMove = true;
        else
            bMove = false;
        return bMove;
    }

    void Start()
    {
        
    }
    private void Awake()
    {
        //playerTran = GameObject.Find("Hero").transform;
        playerTran = GameObject.FindGameObjectWithTag("Player").transform;
        //将一个属性赋给另一个属性，object返回一个值objects返回 一个数组

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void TrackPlayer()
    {
        float newX = transform.position.x;
        float newY = transform.position.y;
        if (NeedMoveX())
            newX = Mathf.Lerp(transform.position.x, playerTran.position.x,
                xSpeed * Time.deltaTime);
        if (NeedMoveY())
            newY = Mathf.Lerp(transform.position.y, playerTran.position.y,
                xSpeed * Time.deltaTime);

        newX = Mathf.Clamp(newX, minXandY.x, maxXandY.x);

        transform.position = new Vector3(newX, newY, transform.position.z);
        //不能直接写transform.position.x = newX;无意义 前面为属性
    }
    private void FixedUpdate()
    {
        TrackPlayer();
    }
}
