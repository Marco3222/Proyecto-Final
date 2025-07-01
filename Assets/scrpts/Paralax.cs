using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour 
{
    public Transform[] backgrounds; 
    public float[] parallaxSpeeds;

    private float cameraHorizontalPosition; 
    private float previousCameraHorizontalPosition; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraHorizontalPosition = Camera.main.transform.position.x;
        if (cameraHorizontalPosition != previousCameraHorizontalPosition)
        {
            for (int i = 0; i < backgrounds.Length; i++)
            {
            float parallax = (previousCameraHorizontalPosition - cameraHorizontalPosition) * parallaxSpeeds[i];
            backgrounds[i].position += new Vector3(parallax, 0f, 0f);
            }
            previousCameraHorizontalPosition = cameraHorizontalPosition;
        }

    }
}
