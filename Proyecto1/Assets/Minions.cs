using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Minions : MonoBehaviour
{
    public float distanciaEncuentro = 0;
    public float distanciaAtaque = 0;
    public NavMeshAgent nav;
    public float speedCaminando=0;
    public float speedCorriendo = 0;
    Animator anim;
    Vector3 posInicial;
    float tiempo = 0;
    void Start()
    {
        anim = GetComponent<Animator>();
        posInicial = new Vector3(transform.position.x + Random.Range(-3, 3), 0.3154334f, transform.position.z + Random.Range(-3, 3));
    }
    public int estado = 0;
    //caminando
    // corriendo = 1;
    // atacando = 2;
    //morir= 3;
    //recibirAtaque=4;
    public Transform aguila;

    
    void Update()  {




        if (estado == 3)
        { //morir= 3;
            nav.speed = 0;
            anim.SetBool("Atacar", false);
            anim.SetBool("Correr", false);
            anim.SetBool("Morir", true);
            anim.SetBool("RecibirAtaque", false);

            return;
        }
        else if (estado == 4)
        {  //recibirAtaque=4;
            anim.SetBool("RecibirAtaque", true);
            anim.SetBool("Atacar", false);
            anim.SetBool("Correr", false);
            anim.SetBool("Morir", false);
            
            nav.speed = 0;
            estado = 2;
            return;
        }

        tiempo += Time.deltaTime;
        if (transform.position == posInicial || tiempo > 8f) {
           
            Vector3 posicionRandom = new Vector3(transform.position.x + Random.Range(-4, 4), transform.position.y, transform.position.z + Random.Range(-4, 4));
            posInicial = posicionRandom;
            tiempo = 0;
        }
        Debug.DrawLine(transform.position, posInicial, Color.red);
      
       
            if (Vector3.Distance(aguila.position, transform.position) > distanciaEncuentro)
            {
                estado = 0;

            }
            else {
                estado = 1;
            if (Vector3.Distance(aguila.position, transform.position) < distanciaAtaque) {

                estado = 2;
            }

                 }

            if (estado == 0)
            {
                nav.SetDestination(posInicial);
                nav.speed = speedCaminando;

                anim.SetBool("Atacar", false);
                anim.SetBool("Correr", false);
                anim.SetBool("Morir", false);
                anim.SetBool("RecibirAtaque", false);
            }
            else if (estado == 1)
            {  // corriendo = 1;
                nav.SetDestination(aguila.position);
                nav.speed = speedCorriendo;

                anim.SetBool("Atacar", false);
                anim.SetBool("Correr", true);
                anim.SetBool("Morir", false);
                anim.SetBool("RecibirAtaque", false);


            }
            else if (estado == 2)
            {   // atacando = 2;
                nav.speed = 0;

                anim.SetBool("Atacar", true);
                anim.SetBool("Correr", false);
                anim.SetBool("Morir", false);
                anim.SetBool("RecibirAtaque", false);


            }
            
            else {

                estado = 0;
            }
        
       
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,distanciaEncuentro);
        Gizmos.DrawWireSphere(transform.position, distanciaAtaque);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pico")) {

            estado = 4;
        }
        
    }
}
