using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObjetos : MonoBehaviour
{
    public float speed = 3;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos= new Vector3(0, 0, speed * Time.deltaTime);
        transform.position += pos;
    }
}
