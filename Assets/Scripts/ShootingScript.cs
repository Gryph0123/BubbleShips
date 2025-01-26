using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{

    // Defines the enemy's gameobject
    public GameObject enemy;

    // Defines the two types of balls that you can shoot
    public GameObject cannonball;
    public GameObject bubbleball;

    // Defines the buttons needed for shooting
    public KeyCode bubbleButton;
    public KeyCode ballbutton;

    // Creates variables to keep track of time
    public float timer = 0f;
    public float coolDown = 0.3f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Updates the timer
        timer += Time.deltaTime;

        if (Input.GetKeyDown(ballbutton) && timer >= coolDown) 
        { 
            // instantiates the cannonball and places it in front of the player
            GameObject cannonballInstance = Instantiate(cannonball, transform.position + transform.forward * 20f + transform.up * 20, Quaternion.identity);

            Debug.Log("Spawned Ball");


            // Gets the boat's heading relative to the x-axis
            float heading = Vector3.SignedAngle(Vector3.right, new Vector3(transform.forward.x, 0f, transform.forward.z), -Vector3.up) * Mathf.Deg2Rad;

            // Finds the azimuth from the projectile to the other boat
            float azimuth = Mathf.Atan((enemy.transform.position.y + 2f - cannonballInstance.transform.position.y) // Height diff
                / (new Vector2(enemy.transform.position.x, enemy.transform.position.z) 
                - new Vector2(cannonballInstance.transform.position.x, cannonballInstance.transform.position.z)).magnitude // Plane diff
                );

            Debug.Log(heading);

            // Converts azimuth and heading into cartesian coordinates
            float x = Mathf.Cos(azimuth) * Mathf.Cos(heading);
            float y = Mathf.Sin(azimuth);
            float z = Mathf.Cos(azimuth) * Mathf.Sin(heading);

            BallFlyingScript ballShooter = cannonballInstance.gameObject.GetComponent<BallFlyingScript>();

            ballShooter.velocity = new Vector3 (x, y, z);

            //Resets timer
            timer = 0f;
        }

        if (Input.GetKeyDown(bubbleButton) && timer >= coolDown)
        {
            // instantiates the cannonball and places it in front of the player
            GameObject cannonballInstance = Instantiate(bubbleball, transform.position + transform.forward * 20f + transform.up * 20, Quaternion.identity);

            Debug.Log("Spawned Ball");


            // Gets the boat's heading relative to the x-axis
            float heading = Vector3.SignedAngle(Vector3.right, new Vector3(transform.forward.x, 0f, transform.forward.z), -Vector3.up) * Mathf.Deg2Rad;

            // Finds the azimuth from the projectile to the other boat
            float azimuth = Mathf.Atan((enemy.transform.position.y - cannonballInstance.transform.position.y) // Height diff
                / (new Vector2(enemy.transform.position.x, enemy.transform.position.z)
                - new Vector2(cannonballInstance.transform.position.x, cannonballInstance.transform.position.z)).magnitude // Plane diff
                );

            Debug.Log(heading);

            // Converts azimuth and heading into cartesian coordinates
            float x = Mathf.Cos(azimuth) * Mathf.Cos(heading);
            float y = Mathf.Sin(azimuth);
            float z = Mathf.Cos(azimuth) * Mathf.Sin(heading);

            BallFlyingScript ballShooter = cannonballInstance.gameObject.GetComponent<BallFlyingScript>();

            ballShooter.velocity = new Vector3(x, y, z);

            // Resets the timer
            timer = 0f;
        }

    }
}
