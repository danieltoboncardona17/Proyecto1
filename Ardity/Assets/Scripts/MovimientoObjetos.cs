using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObjetos : MonoBehaviour
{
    public float speed = 4.5f;
    Runner run;
    
    void Start()
    {
        run = GameObject.Find("Indicador").GetComponent<Runner>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = run.speed;
        
        Vector3 pos= new Vector3(0, 0, speed * Time.deltaTime);
        transform.position += pos;
    }
}
