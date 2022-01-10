using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIghwayCar : MonoBehaviour
{
    public bool goLeft;

    public GameObject rSide;
    public GameObject lSide;

    public float rLimit;
    public float lLimit;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goLeft)
        {
            gameObject.transform.position += Vector3.left * (speed * Time.deltaTime);
        }
        else
        {
            gameObject.transform.position += Vector3.right * (speed * Time.deltaTime);
        }

        CheckRestart();
    }

    void CheckRestart() {
        if(transform.position.x < lLimit && goLeft)
        {
            gameObject.transform.localPosition = new Vector3(rSide.transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        } else if(transform.position.x > rLimit && !goLeft)
        {
            gameObject.transform.localPosition = new Vector3(lSide.transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }
    }

 
}
