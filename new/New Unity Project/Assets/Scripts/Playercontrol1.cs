using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol1 : MonoBehaviour
{
    public float force = 5;
    private Rigidbody2D heroBody;
    // Start is called before the first frame update
    void Start()
    {
        heroBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        //  if ()
        heroBody.AddForce(Vector2.right * h * force);
    }
}
