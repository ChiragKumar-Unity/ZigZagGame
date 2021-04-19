using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    bool Started;
    bool gameOver;
    Rigidbody rb;
    public GameObject particle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                Started = true;

                GameManager.instance.GameStart();
            }
        }

        // to show the ray
        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        // to add a ray and check collision between the platworm and the ball through ray
        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        //                    origin      ,      direction, distance
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -25f , 0);

            // to access the script of camera and change the value of gameOver var
            Camera.main.GetComponent<CameraFollow>().gameOver = true;

            GameManager.instance.GameOver();
        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }
    }

    void SwitchDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        } 
        else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Diamond")
        {
            GameObject Part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            //                                                                                                imp for storing it as a simple game object           
            Destroy(col.gameObject);
            Destroy(Part , 1f);
            //       obj , after what time
        }
    }
}
