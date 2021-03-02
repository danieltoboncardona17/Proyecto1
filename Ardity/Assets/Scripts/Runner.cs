using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public List<GameObject> lista = new List<GameObject>();
    public GameObject instanciador;
    float timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>4) {
            GameObject obj = lista[Random.Range(0, lista.Count)];
            GameObject.Instantiate(obj, instanciador.gameObject.transform.position, obj.transform.rotation);
            timer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Terminacion") {
            

        }
    }
}
