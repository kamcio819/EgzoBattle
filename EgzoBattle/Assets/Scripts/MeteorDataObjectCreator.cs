using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

public class MeteorDataObjectCreator : EditorWindow
{
   private Material meteorDataObjectMaterial;
   private ParticleSystem meteorDataObjectParticle;
   private float meteorDataObjectMovementSpeed;
   private float meteorDataObjectRotationSpeed;
   private string meteorDataObjectName;

   [MenuItem("Window/General/CreateMeteor")]
   public static void ShowSoundItemWindow () {
      EditorWindow.GetWindow(typeof(MeteorDataObjectCreator));
   }

   public void OnGUI() {

      EditorGUILayout.BeginVertical();

      meteorDataObjectMaterial = EditorGUILayout.ObjectField(
         "Meteor material",
         meteorDataObjectMaterial,
         typeof(Material),    
         true) 
         as Material;
      meteorDataObjectParticle = EditorGUILayout.ObjectField(
         "Meteor particles",
         meteorDataObjectMaterial,
         typeof(ParticleSystem),    
         true) 
         as ParticleSystem;
      meteorDataObjectMovementSpeed = EditorGUILayout.FloatField("Meteor movement speed", meteorDataObjectMovementSpeed);
      meteorDataObjectRotationSpeed = EditorGUILayout.FloatField("Meteor rotation speed", meteorDataObjectRotationSpeed);
      meteorDataObjectName = EditorGUILayout.TextField("Meteor name", meteorDataObjectName);

      GUILayout.Space(20);

      if(GUILayout.Button("Create Meteor!")) {
         CreateMeteorDataObject();
      }

      EditorGUILayout.EndVertical();
   }

   public void CreateMeteorDataObject() {
      MeteorDataObject meteorDataObject = ScriptableObject.CreateInstance<MeteorDataObject>();
      meteorDataObject.meteorMaterial = meteorDataObjectMaterial;
      meteorDataObject.particleSystem = meteorDataObjectParticle;
      meteorDataObject.meteorMovementSpeed = meteorDataObjectMovementSpeed;
      meteorDataObject.meteorRotationSpeed = meteorDataObjectRotationSpeed;
      meteorDataObject.name = meteorDataObjectName;


      AssetDatabase.CreateAsset(
                  meteorDataObject, 
                  "Assets/ScriptableObjects/Meteor/" + meteorDataObject.name + ".asset");

      AssetDatabase.SaveAssets();
      EditorUtility.FocusProjectWindow();
   } 
}

#endif