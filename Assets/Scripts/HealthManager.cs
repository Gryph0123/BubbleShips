using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float playerHealth = 100.0f;

    public float damagePerBall = 5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0) 
        { 

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Is activated when boat is hit by the cannon
        if (collision.gameObject.layer == 3)
        {
            playerHealth -= damagePerBall;

        }
    }
}
