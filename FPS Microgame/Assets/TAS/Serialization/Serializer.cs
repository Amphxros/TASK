using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Serializer : MonoBehaviour
{
    public string file;
    public void serializa(Queue<InputObject> input_) {
        while (input_.Count > 0) {
            InputObject aux = input_.Peek();
            File.AppendAllText(file, aux.key + " " + aux.mMinutes_ + " " + aux.mSeconds_ + "\n");
            input_.Dequeue();
        }
    }
}
