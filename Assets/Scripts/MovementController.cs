using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce;
    public float angularForce;

    // Defines each floater on the boat
    public GameObject FRFloater;
    public GameObject FLFloater;
    public GameObject BRFloater;
    public GameObject BLFloater;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        
        //Forward movement
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * forwardForce);
        }

        // Clockwise movement
        if (Input.GetKey(KeyCode.D)) 
        {

            // Applies forces to all the floaters
            rb.AddForceAtPosition(rb.transform.right * angularForce, FRFloater.transform.position);
            rb.AddForceAtPosition(rb.transform.right * angularForce, FLFloater.transform.position);

            rb.AddForceAtPosition(-rb.transform.right * angularForce, BRFloater.transform.position);
            rb.AddForceAtPosition(-rb.transform.right * angularForce, BLFloater.transform.position);

        }

        // Counter-clockwise movement
        if (Input.GetKey(KeyCode.A)) 
        {

            // Applies forces to all the floaters
            rb.AddForceAtPosition(-rb.transform.right * angularForce, FRFloater.transform.position);
            rb.AddForceAtPosition(-rb.transform.right * angularForce, FLFloater.transform.position);

            rb.AddForceAtPosition(rb.transform.right * angularForce, BRFloater.transform.position);
            rb.AddForceAtPosition(rb.transform.right * angularForce, BLFloater.transform.position);
        }

        

    }
}
