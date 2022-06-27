using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TASKManager))]
public class TASKManagerEditor :  Editor
{ 
    public override void OnInspectorGUI() {
       
        base.OnInspectorGUI();
        var mManager= (TASKManager)target;
            EditorGUILayout.LabelField( "Controls", EditorStyles.boldLabel );
            
             using ( var playGroup = new EditorGUILayout.HorizontalScope() ) {

              if ( GUILayout.Button( "PLAY >", EditorStyles.miniButtonLeft ) ){

              }
              if ( GUILayout.Button( "PAUSE ||", EditorStyles.miniButtonRight ) ) {
            
              }


            }

            using ( var recordGroup = new EditorGUILayout.HorizontalScope() ) { 
                if ( GUILayout.Button( "STOP []", EditorStyles.miniButtonLeft )){
            
                }
                if ( GUILayout.Button( "REWIND <<", EditorStyles.miniButtonRight ) ) {
                
                }
         
            }
         GUI.enabled = true;
    }
}
