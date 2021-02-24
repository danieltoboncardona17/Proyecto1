using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Escena : MonoBehaviour
{
    public string comArduino;
    public string baudArduino;
    public string comESP;
    public string baudESP;
    public InputField iComA;
    public InputField iBaudA;
    public InputField iComEsp;
    public InputField iBaudEsp;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cambioEscena(int escena) {

        SceneManager.LoadScene(escena);
        comArduino = iComA.text;
        baudArduino = iBaudA.text;
        comESP = iComEsp.text;
        baudESP = iBaudEsp.text;
    }

}
