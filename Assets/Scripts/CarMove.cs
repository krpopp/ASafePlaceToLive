using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public int dir;
    Vector3 startPos;

    float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        //dir = Random.Range(0, 2);
        if(dir != 1)
        {
            //gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 200f);
        }
        startPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (dir == 1)
        {
            gameObject.transform.position += Vector3.back * (speed * Time.deltaTime);
        }
        else
        {
            gameObject.transform.position += Vector3.forward * (speed * Time.deltaTime);
        }
        if(Vector3.Distance(startPos, gameObject.transform.position) > 300f)
        {
            Destroy(gameObject);
        }
    }
}
