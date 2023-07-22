using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody myBody;
    private characterAnimation player_Anim;
    public float walk_Speed = 2f;
    public float z_Speed = 1.5f;

    private float rotation_y = -90f;
    //private float rotation_speed = 15f;
    // Start is called before the first frame update
   //

    // Update is called once per frame
    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        player_Anim = GetComponentInChildren<characterAnimation>();
    }

    void Update()
    {
        RotatePlayer();
        AnimatePlayerWalk();
    }
    private void FixedUpdate()
    {
        DetectMovement();
    }

    void DetectMovement()
    {
        myBody.velocity = new Vector3(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS)*(-walk_Speed),
            myBody.velocity.y,
            Input.GetAxisRaw(Axis.VERTICAL_AXIS)*(-z_Speed)   
            );
    }
    // movement

    void RotatePlayer()
    {
        if (Input.GetAxis(Axis.HORIZONTAL_AXIS) > 0)
        {
            transform.rotation = Quaternion.Euler(0f, -Mathf.Abs(rotation_y), 0f);
        }
        else if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS)<0)
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotation_y), 0f);
        }
    }

    void AnimatePlayerWalk() 
    {
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) !=0 ||
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) !=0) 
        {
            player_Anim.Walk(true);
        }
        else
        {
            player_Anim.Walk(false);
        }
    }
}
