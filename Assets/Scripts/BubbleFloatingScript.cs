using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleFloatingScript : MonoBehaviour
{
    // Makes values to keep track of time
    public float timer = 0f;
    public float floatingTime;

    // Transparent bubble effect around the player
    public GameObject bubble;

    // Gets rigidbody
    public Rigidbody rb;

    // defines the force at which the bubble floats up
    public float BubbleFloatingForce;

    public float maxUpwardsSpeed;

    // Holds whether or not the ship is in the bubble
    public bool isInBubble;

    // Cameras
    public GameObject cinemaCamera;
    public GameObject camera;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (isInBubble)
        {
            // Updates the timer
            timer += Time.deltaTime;

            // Makes boat float
            rb.useGravity = false;
            rb.AddForce(transform.up * BubbleFloatingForce);
            rb.velocity = new Vector3(0.0f, Mathf.Clamp(rb.velocity.y, 0, maxUpwardsSpeed), 0.0f);

            // Checks if the bubble has run out of time
            if (timer >= floatingTime) 
            {
                // Undoes everything that was done when the bubble formed
                isInBubble = false;
                bubble.SetActive(false);
            }

            // Camera follows the cinema cam
            camera.transform.position = cinemaCamera.transform.position;
            camera.transform.localRotation = cinemaCamera.transform.localRotation;


        }
        else
        {
            // Follows the cinema camera but does not follow the y-axis
            camera.transform.position = new Vector3(cinemaCamera.transform.position.x, 22f, cinemaCamera.transform.position.z);
            camera.transform.localRotation = cinemaCamera.transform.localRotation;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        // Is activated when boat is hit by the bubble
        if (collision.gameObject.layer == 6)
        {

            isInBubble = true;
            // Shows bubble effect
            bubble.SetActive(true);

            // Resets the timer
            timer = 0f;



        }
    }
}
