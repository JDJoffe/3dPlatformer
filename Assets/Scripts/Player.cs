using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float jumpHeight = 4f;
    public float groundDistance = 10f;
    public bool isGrounded;
    public Rigidbody rigid;
    public Vector3 Velocity = Vector3.zero;
   
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (groundDistance <= 1)
        {
            isGrounded = true;
        }
        else { isGrounded = false; }

        // cap velocity at 4 or -4 for X and Z, cap at 10 or -10 for Y

        //Vector3 clampX = rigid.velocity;
        //clampX.x = Mathf.Clamp(clampX.x, 0, maxVelocity.x);
        //rigid.velocity = clampX;
        //Vector3 clampY = rigid.velocity;
        //clampY.y = Mathf.Clamp(clampY.y, 0, maxVelocity.y);
        //rigid.velocity = clampY;
        //Vector3 clampZ = rigid.velocity;
        //clampZ.z = Mathf.Clamp(clampZ.z, 0, maxVelocity.z);
        //rigid.velocity = clampZ;

        //Mathf.Clamp(rigid.velocity.x, 0, maxVelocity.x);
        //Mathf.Clamp(rigid.velocity.y, 0, maxVelocity.y);
        //Mathf.Clamp(rigid.velocity.z, 0, maxVelocity.z);
        Movement();


        //  Vector3 fallingSpeed = rigid.velocity.normalized * jumpHeight;
      
    }
    private void FixedUpdate()
    {
       
    }
    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Mathf.Clamp(transform.up.normalized.y, 0, jumpHeight);
            rigid.AddForce(transform.up.normalized * jumpHeight, ForceMode.Impulse);
        }
        // W
        // add impulse force to transform.forward aslong as the rigidbody.velocity.z is under 4 and W is pressed
        if (Input.GetKey(KeyCode.W) && rigid.velocity.z < 4)
        {
            Mathf.Clamp(transform.forward.normalized.z, 0, moveSpeed);
            rigid.AddForce(transform.forward.normalized, ForceMode.VelocityChange);
            //rigid.velocity = transform.forward.normalized * moveSpeed;
        }
        // A
        // add impulse force to -transform.right aslong as the rigidbody.velocity.x is over -4 and A is pressed
        if (Input.GetKey(KeyCode.A) && rigid.velocity.x > -4)
        {
            Mathf.Clamp(-transform.right.normalized.x, 0, moveSpeed);
            rigid.AddForce(-transform.right.normalized, ForceMode.VelocityChange);
        }
        // S
        // add impulse force to -transform.forward aslong as the rigidbody.velocity.z is over -4 and S is pressed
        if (Input.GetKey(KeyCode.S) && rigid.velocity.z > -4)
        {
            Mathf.Clamp(-transform.forward.normalized.z, 0, moveSpeed);
            rigid.AddForce(-transform.forward.normalized, ForceMode.VelocityChange);
        }
        // D
        // add impulse force to transform.right aslong as the rigidbody.velocity.x is under 4 and D is pressed
        if (Input.GetKey(KeyCode.D) && rigid.velocity.x < 4)
        {
            Mathf.Clamp(transform.right.normalized.x, 0, moveSpeed);
            rigid.AddForce(transform.right.normalized, ForceMode.VelocityChange);
            
        }
        Velocity = rigid.velocity;


    }
   
    void OnDrawGizmos()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            groundDistance = hit.distance;
            Debug.DrawLine(transform.position, hit.point, Color.cyan);
        }
    }

}
