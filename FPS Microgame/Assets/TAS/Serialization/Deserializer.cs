using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deserializer
{

   public List<InputObject> deserialize(string file){
       List<InputObject> input= new List<InputObject>();

        StreamReader read= new StreamReader(file);
        int i=0;
        while(!read.EndOfStream){

            string line = read.ReadLine();

            string [] words= line.Split(' ');
            InputObject obj= new InputObject();
            obj.key= words[0]; //source of the input
            switch(words[0]){
                case "keyboard":
                obj.key+= " " + words[1];
                obj.mMinutes_= int.Parse(words[2]);
                obj.mMinutes_=int.Parse(words[3]);
                break;

                case "mouse":
                
                break;

            }
            

            input.Insert(i,obj);
            i++;

        }
        return input;
   }
}
