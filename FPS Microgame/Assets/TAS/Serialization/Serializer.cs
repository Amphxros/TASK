using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Serializer 
{
    string mFile_;
    public Serializer(string file){
        this.mFile_=file;
    }
    public void serializa( Queue<InputObject> input_) {
        while (input_.Count > 0) {
            InputObject aux = input_.Peek();
            File.AppendAllText(mFile_, aux.key + " " + aux.mMinutes_ + " " + aux.mSeconds_ + "\n");
            input_.Dequeue();
        }
    }
}
