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



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S)) 
        { 

            // instantiates the cannonball and places it in front of the player
            GameObject cannonballInstance = Instantiate(cannonball, transform.position + transform.forward * 20f, Quaternion.identity);

            Debug.Log("Spawned Ball");

            


        }

    }
}
