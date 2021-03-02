using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public float speed=2;
    float timer = -1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timer);
        if (timer>=0)
        {
            timer += Time.deltaTime;
            if (timer>=1)
                timer += -Time.deltaTime;

        }
        else if ( timer <= 0) {
            timer += -Time.deltaTime;
            if (timer<=-1)
                timer += +Time.deltaTime;
        }
        
        Vector3 vec = new Vector3(0, timer *speed *Time.deltaTime,0);
        this.gameObject.transform.position += vec;
    }
}
