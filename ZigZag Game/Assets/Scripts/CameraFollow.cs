using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject target;
    Vector3 offset; // distance between camera and ball
    public float lerpRate; // this is the rate by which camera will change its pos and follow ball
    public bool gameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Follow();
        }
    }

    // to make the camera follow
    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = target.transform.position - offset;
        pos = Vector3.Lerp(pos , targetPos , lerpRate * Time.deltaTime);
        // lerp function moves on from one value to another with a rate 
        transform.position = pos;
    }
}
