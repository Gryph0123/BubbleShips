using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

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


    // Defines the buttons used for movement
    public KeyCode fwd;
    public KeyCode right;
    public KeyCode left;


    // Ref to the water surface manager
    public WaterSurface water;

    // This holds the paramaters necciary in
    // order to search the water surface
    WaterSearchParameters Search;

    // Stores the results of the water surface search
    WaterSearchResult SearchResult;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        

        //Forward movement
        if (Input.GetKey(fwd))
        {
            // Projects to the water and gets the result
            water.ProjectPointOnWaterSurface(Search, out SearchResult);

            if (transform.position.y < SearchResult.projectedPositionWS.y)
            {
                rb.AddForce(transform.forward * forwardForce);
            }
                
        }

        // Clockwise movement
        if (Input.GetKey(right)) 
        {

            // Applies forces to all the floaters
            rb.AddForceAtPosition(rb.transform.right * angularForce, FRFloater.transform.position);
            rb.AddForceAtPosition(rb.transform.right * angularForce, FLFloater.transform.position);

            rb.AddForceAtPosition(-rb.transform.right * angularForce, BRFloater.transform.position);
            rb.AddForceAtPosition(-rb.transform.right * angularForce, BLFloater.transform.position);

        }

        // Counter-clockwise movement
        if (Input.GetKey(left)) 
        {

            // Applies forces to all the floaters
            rb.AddForceAtPosition(-rb.transform.right * angularForce, FRFloater.transform.position);
            rb.AddForceAtPosition(-rb.transform.right * angularForce, FLFloater.transform.position);

            rb.AddForceAtPosition(rb.transform.right * angularForce, BRFloater.transform.position);
            rb.AddForceAtPosition(rb.transform.right * angularForce, BLFloater.transform.position);
        }

        

    }
}
