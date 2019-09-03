using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight = 5f;
    public float groundDistance;
    public bool isGrounded;
    public Rigidbody rigid;
  
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         
      
       
    }
    public void FixedUpdate()
    {
      
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigid.velocity = new Vector3(0,jumpHeight,0);
        }
    }
    public void OnDrawGizmos()
    {
        Physics.Raycast(transform.position, -Vector3.up, groundDistance + 0.1f);
    }
    public void IsGrounded()
    {
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, groundDistance + 0.1f);
    }

}
