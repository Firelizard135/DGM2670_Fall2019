using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject targObj;

    private float yOffset;
    private float zOffset;

    private Vector3 cameraPos;
    private Vector3 targPos;

    void Start()
    {
        yOffset = transform.position.y-targObj.transform.position.y;
        zOffset = -transform.position.z-targObj.transform.position.z;
    }

    void FixedUpdate()
    {
        cameraPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        targPos = new Vector3(targObj.transform.position.x, targObj.transform.position.y+yOffset, targObj.transform.position.z-zOffset);

        transform.Translate( targPos-cameraPos );
    }
}
