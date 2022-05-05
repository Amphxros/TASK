using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    

    public static GameManager instance;
    public TextAsset inputText;
    private string[] instruccionesArray;
    private int nTotalInstrucciones;
    private int instruccionesLeido = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        ExtraerInstruccion();
    }

    public string getInstruccion() {

        instruccionesLeido++;

        return instruccionesArray[instruccionesLeido]; 
    }
    private void ExtraerInstruccion()
    {
        string contenido = inputText.text;

        instruccionesArray = contenido.Split('\n');
        nTotalInstrucciones = int.Parse( instruccionesArray[0]);

        int n = instruccionesArray.Length - nTotalInstrucciones;
        if ( n != 1)
        {
            if (n < 1)
                Debug.LogError("número de instrucciones son menos que lo que propuesto");
        }
    }

    


    
}
