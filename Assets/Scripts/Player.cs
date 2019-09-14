using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 5f;
    public float groundDistance =10f;
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

        if (groundDistance <=1 )
        {
            isGrounded = true;
        }
        else { isGrounded = false; }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigid.velocity = new Vector3(0, jumpHeight, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rigid.velocity = transform.forward * moveSpeed;
           
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigid.velocity = -transform.right * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigid.velocity = -transform.forward * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigid.velocity = transform.right * moveSpeed;
        }
    }
    private void OnDrawGizmos()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            groundDistance = hit.distance;
            Debug.DrawLine(transform.position, hit.point, Color.cyan);
        }
    }


    
   

}
