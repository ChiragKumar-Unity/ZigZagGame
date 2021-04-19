using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // this func gets automatically called by unity when an object passes through this trigger
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ball")
        {
            // to call the func after some time
            Invoke("FallDown", 0.01f);
            //       NAME    , time
        }
    }

    void FallDown()
    {
        // to get the component gravity of the parent of the object and set it true
        GetComponentInParent<Rigidbody>().useGravity = true;
        // to destroy the parent
        Destroy(transform.parent.gameObject, 2f);
        //              object             , time
    }
}
