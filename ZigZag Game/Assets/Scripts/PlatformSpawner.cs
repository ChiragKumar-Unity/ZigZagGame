using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public GameObject platform;
    public GameObject diamond;

    Vector3 lastPos;
    float size;
    public bool gameOver;


    // Start is called before the first frame update
    void Start()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;
            for (int i = 0; i < 20; i++)
            {
                SpawnPlatforms();
            }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameOver == true)
        {
            CancelInvoke(); // cancels the Invoke
            //return; // get out of the func and not do anything if the game is over
        }
    }

    void SpawnPlatforms()
    {

        int rand = Random.Range(0, 6); // upto 5
        if (rand < 3)
        {
            SpawnX();

        } else if (rand >= 3)
        {
            SpawnZ();
        }
    }

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;

        Instantiate(platform, pos, Quaternion.identity);
        //            obj   , pos ,     rotation
        lastPos = pos;

        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1.22f, pos.z), Quaternion.identity);

        }

    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;

        Instantiate(platform, pos, Quaternion.identity);
        //            obj   , pos ,     rotation
        lastPos = pos;

        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x , pos.y + 1.22f , pos.z), Quaternion.identity);

        }
    }

    public void StartSpawningPlatforms()
    {
        // allows us to repeat something again and again after specific time
        InvokeRepeating("SpawnPlatforms", 0.1f, 0.2f);
        //                       func      , wait , repeating time
    }
}
