using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    Vector3 m_NewPosition;
    Quaternion m_NewRotation;

    // Start is called before the first frame update
    void Start()
    {
        // Initialise the vectors
        m_NewPosition = target.position;
        //m_NewRotation = target.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        GetCameraPosition();
        transform.LookAt(target);
        //GetCameraRotation();
    }
    void GetCameraPosition() 
    {
        //Update the new camera positions
        m_NewPosition.x = target.position.x + 1;
        m_NewPosition.y = target.position.y + 2;
        m_NewPosition.z = target.position.z - 3;
        //Update the new camera rotations
        //m_NewPosition.x = target.rotation.x + 1;
        //m_NewPosition.y = target.rotation.y + 2;
        //m_NewRotation.z = target.rotation.z;
        // Change the position depending on the vector
        transform.position = m_NewPosition;
        // Change the rotation depending on the vector
        transform.rotation = Quaternion.LookRotation(target.forward,target.up);
    }
    //void GetCameraRotation()
    //{
    //    m_NewPosition. = target.position.x + 1;
    //    m_NewPosition.y = target.position.y + 3;
    //    m_NewPosition.z = target.position.z - 3;
    //}
}
