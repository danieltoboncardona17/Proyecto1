/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;

using System.Collections;

/**
 * Sample for reading using polling by yourself, and writing too.
 */
public class Movimiento : MonoBehaviour
{
    public GameObject pajaro;
    public int speedAdelante = 0;
    public int speedArriba = 0;
    public SerialController serialController;
    public SerialControllerBinario serialControllerBinario;
    public GameObject minions;
    byte[] messageBinario =  { 0x0 };
    // Initialization
    void Start()
    {
      
        
        
    }

    // Executed each frame
    void Update()
    {
     
     
        string message = serialController.ReadSerialMessage();
        messageBinario = serialControllerBinario.ReadSerialMessage(); ; //
       
       
      
         
        if (message != null )
        {
            float cm = 0;
            float.TryParse(message ,out cm);;
            
            float velocidad = speedAdelante * 1 * Time.deltaTime;
            Vector3 vectorDesplazamiento = transform.forward * velocidad ;
            Vector3 vectorY = new Vector3(transform.position.x, cm, transform.position.z);

            pajaro.gameObject.transform.position += vectorDesplazamiento;
            transform.position= Vector3.MoveTowards(transform.position, vectorY, speedArriba * Time.deltaTime);
          
        }

        if (messageBinario ==null)
        {
            return;
        }
            if (messageBinario[0] == 1)
        {
            
            pajaro.gameObject.GetComponent<Animator>().SetTrigger("Attack");

            pajaro.transform.LookAt(minions.transform);

        }

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        else
            Debug.Log("Message arrived: " + message);
    }
}
