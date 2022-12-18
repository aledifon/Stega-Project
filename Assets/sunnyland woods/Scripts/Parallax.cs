using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float distanceX;//Represent to which "distance" is the background
    public float distanceY;//Represent to which "distance" is the background
    public float smoothing;//speed

    Transform cam;
    Vector3 previousCamPos;//var. to save the camera pos. in the previous frame
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        previousCamPos = cam.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (distanceX != 0)
        {
            float parallaxX = (previousCamPos.x - cam.position.x) * distanceX;
            float parallaxY = (previousCamPos.y - cam.position.y) * distanceY;

            Vector3 backgroundTargetPosX = new Vector3(transform.position.x + parallaxX,
                                                        transform.position.y + parallaxY, 
                                                        transform.position.z);

            transform.position = Vector3.Lerp(transform.position, backgroundTargetPosX, smoothing * Time.deltaTime);

            previousCamPos = cam.position;
        }
    }
}
