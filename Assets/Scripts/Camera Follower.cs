using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    public GameObject cinemaCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Updates the camera position and rotation
        transform.position = new Vector3(cinemaCamera.transform.position.x, transform.position.y, cinemaCamera.transform.position.z);
        transform.localRotation = cinemaCamera.transform.localRotation;
    }
}
