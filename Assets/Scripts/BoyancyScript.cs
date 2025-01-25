using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class BoyancyScript : MonoBehaviour
{

    // Defines rigidbody
    public Rigidbody rb;

    // defines the depth at which the object begins to feel boyancy
    public float depthBefSub;

    // The amount of boyancy that is applied to the object
    public float displacementAmt;

    // # of points applying a boiant force on the object
    public int floaters;

    // Drag coefficent in the water
    public float waterDrag;

    // angular drag coefficent in water
    public float waterAngularDrag;

    // Ref to the water surface manager
    public WaterSurface water;


    // This holds the paramaters necciary in
    // order to search the water surface
    WaterSearchParameters Search;

    // Stores the results of the water surface search
    WaterSearchResult SearchResult;

    private void FixedUpdate()
    {

        // Applys a gravitational force to the object
        rb.AddForceAtPosition(Physics.gravity / floaters, transform.position, ForceMode.Acceleration);

        // Sets up the search paramaters for projecting onto the water surface
        Search.startPositionWS = transform.position;

        // Projects to the water and gets the result
        water.ProjectPointOnWaterSurface(Search, out SearchResult);

        // Runs if the object is below the water
        if (transform.position.y < SearchResult.projectedPositionWS.y)
        {

            // Calculates the displacement multiplier based on the
            // depth under the water
            float displacementMulti = Mathf.Clamp01((SearchResult.projectedPositionWS.y 
                - transform.position.y) / depthBefSub) * displacementAmt;

            // Applys the upwards boyant force
            rb.AddForceAtPosition(new Vector3(0f,
                Mathf.Abs(Physics.gravity.y) * displacementMulti, 0f), 
                transform.position, ForceMode.Acceleration);

            // Applys water drag
            rb.AddForce(displacementMulti * -rb.velocity * waterDrag * Time.fixedDeltaTime,
              ForceMode.VelocityChange);

            // Applys water angular drag
            rb.AddForce(displacementMulti * -rb.angularVelocity * waterAngularDrag * Time.fixedDeltaTime,
               ForceMode.VelocityChange);

        }
    }
}
