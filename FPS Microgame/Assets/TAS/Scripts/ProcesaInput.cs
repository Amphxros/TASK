using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ProcesaInput : MonoBehaviour
{
    public int instruccionesAprocesar;
    int instruccionesProcesado =0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (instruccionesProcesado < instruccionesAprocesar)
        {

            string inst = GameManager.instance.getInstruccion();
            instruccionesProcesado++;
            
        }
    }

    void TraducirInput( string inst)
    {
        string[] caracteristicas = inst.Split(' ');
        int tipo = int.Parse(caracteristicas[0]);
        switch (tipo)
        {
            case 0:
                InstruccionMouse mouse = new InstruccionMouse(caracteristicas[1], caracteristicas[2].Split(','));
                ProcesaMouse(mouse);
                break;
            case 1:
                InstruccionKeycode key = new InstruccionKeycode(caracteristicas[1], caracteristicas[2]);
                ProcesaKey(key);
                break;
            case 2:
                InstruccionWait wait = new InstruccionWait(caracteristicas[1]);
                ProcesaWait(wait);
                break;
        }
    }
    void ProcesaMouse (InstruccionMouse m)
    {
        switch( SceneManager.GetActiveScene().name)
        {
            case "IntroMenu":
            case "LoseScene":
            case "WinScene":

                break;
            case "MainScene":
            case "SecondaryScene":
                break;
        }
    }
    void ProcesaKey(InstruccionKeycode k)
    {

    }
    void ProcesaWait(InstruccionWait wait)
    {

    }

}
