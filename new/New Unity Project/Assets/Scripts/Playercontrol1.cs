using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol1 : MonoBehaviour
{
    private Rigidbody2D heroBody;
    public float moveForce = 100;
    public float jumpForce = 200;
    private float fInput = 0.0f;
    public float MaxSpeed = 5;
    private bool bFaceRight = true; 
    private bool bGrounded = false; //在地上
    Transform mGroundCheck;
    // Start is called before the first frame update
    void Start()
    {
        heroBody = GetComponent<Rigidbody2D>(); 
        mGroundCheck = transform.Find("GroundCheck");
    }
    // Update is called once per frame
    void Update()
    {
        fInput = Input.GetAxis("Horizontal");
        heroBody.AddForce(Vector2.right * fInput * moveForce);

        if (fInput > 0 && !bFaceRight)
            flip();
        else if (fInput < 0 && bFaceRight)
            flip();
        bGrounded = Physics2D.Linecast(transform.position,mGroundCheck.position, 1 <<
 LayerMask.NameToLayer("Ground"));
        //nametolayer
        
    }
    void flip() //翻转
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        bFaceRight = !bFaceRight;
    }
    private void FixedUpdate() //对物体的操作
    {
        if (Mathf.Abs(heroBody.velocity.x) < MaxSpeed)
        {//fInput * rigidBody.velocity.x < MaxSpeed 
            heroBody.AddForce(fInput * moveForce * Vector2.right);
        }
        if (Mathf.Abs(heroBody.velocity.x) > MaxSpeed)
        {
            heroBody.velocity = new Vector2(Mathf.Sign(heroBody.velocity.x) 
                * MaxSpeed, heroBody.velocity.y);
        }
        bool bJump = false;
        if (bGrounded)
        {
            bJump = Input.GetKeyDown(KeyCode.Space);
            Vector2 upForce = new Vector2(0,1);
            if (bJump)
            {
                heroBody.AddForce(upForce * jumpForce);
                //向上加力
            }
        }
    }
 

}