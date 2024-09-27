using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personazcontroller : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Animator animator;
    public float speed = 2f;
    public float rotationSpeed = 10f;
    public bool ground;
    public float jumpPower = 200f;
    public Rigidbody rb;
    public bool jump;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 directionVector = new Vector3(h, 0, v);
        directionVector = transform.TransformDirection(directionVector);

       // if (directionVector.magnitude > Mathf.Abs(0.1f))
        //{
         //   transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionVector), Time.deltaTime * 10);
        //}
        animator.SetFloat("speed", Vector3.ClampMagnitude(directionVector, 1).magnitude);
        rigidbody.velocity = Vector3.ClampMagnitude(directionVector, 1) * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ground == true)
            {
                rb.AddForce(transform.up * jumpPower);
            }
        }

        if (jump == true)
        {
            rb.AddForce(transform.up * jumpPower);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            ground = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            ground = false;
        }
    }
}
