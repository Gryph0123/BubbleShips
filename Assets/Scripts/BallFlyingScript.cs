using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFlyingScript : MonoBehaviour
{
    // Creates velocity public so that it can be acsessed by all methods
    public Vector3 velocity = Vector3.zero;

    // Magnitude of velocity
    public float speed;

    // Creates variables to keep track of time
    public float flyingTimeoutTime = 10f; // Ball despawns after these many seconds



    // Start is called before the first frame update
    void Start()
    {
        // Scales the velocity in accordance with the speed
        velocity *= speed;

        Debug.Log(velocity);
    }

    // Update is called once per frame
    void Update()
    {

        // Destroys the object if it runs out of time
        Destroy(this.gameObject, flyingTimeoutTime);

        // updates the position of the ball
        transform.position += velocity * Time.deltaTime;
    }

    //Destroys the ball if it hits anything
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        Debug.Log("Destroyed ball due to collision");

    }
}
