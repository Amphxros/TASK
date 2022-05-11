using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(TASManager))]
public class TASManagerEditor : Editor
{
     public override void OnInspectorGUI() {


            var mManager= (TASManager)target;

            if(mManager.gameMode_==GM.PLAYINGINPUT){
            // record controls
            EditorGUILayout.LabelField( "Controls", EditorStyles.boldLabel );

              // controls
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

         base.OnInspectorGUI();
     }
}
