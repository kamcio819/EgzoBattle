using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

public class MeteorDataObjectCreator : EditorWindow
{
    private Material meteorDataObjectMaterial;
    private GameObject meteorDataObjectParticle;
    private float meteorDataObjectMovementSpeed;
    private float meteorDataObjectRotationSpeed;
    private string meteorDataObjectName;

    [MenuItem("Window/General/CreateMeteor")]
    public static void ShowSoundItemWindow()
    {
        EditorWindow.GetWindow(typeof(MeteorDataObjectCreator));
    }

    public void OnGUI()
    {

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
           as GameObject;
        meteorDataObjectMovementSpeed = EditorGUILayout.FloatField("Meteor movement speed", meteorDataObjectMovementSpeed);
        meteorDataObjectRotationSpeed = EditorGUILayout.FloatField("Meteor rotation speed", meteorDataObjectRotationSpeed);
        meteorDataObjectName = EditorGUILayout.TextField("Meteor name", meteorDataObjectName);

        GUILayout.Space(20);

        if (GUILayout.Button("Create Meteor!"))
        {
            CreateMeteorDataObject();
        }

        EditorGUILayout.EndVertical();
    }

    public void CreateMeteorDataObject()
    {
        MeteorDataObject meteorDataObject = ScriptableObject.CreateInstance<MeteorDataObject>();
        meteorDataObject.Material = meteorDataObjectMaterial;
        meteorDataObject.ParticleSystem = meteorDataObjectParticle;
        meteorDataObject.MovementSpeed = meteorDataObjectMovementSpeed;
        meteorDataObject.RotationSpeed = meteorDataObjectRotationSpeed;
        meteorDataObject.Name = meteorDataObjectName;


        AssetDatabase.CreateAsset(
                    meteorDataObject,
                    "Assets/ScriptableObjects/Meteor/" + meteorDataObject.Name + ".asset");

        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
    }
}

#endif