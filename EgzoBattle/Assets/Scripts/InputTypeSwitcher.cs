using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

public class InputTypeSwitcher : EditorWindow
{
    [MenuItem("Window/General/InputType")]
   public static void ShowSoundItemWindow () {
      EditorWindow.GetWindow(typeof(InputTypeSwitcher));
   }

   private void OnGUI() {
       if(GUILayout.Button("Luna Input")) {
         PlayerInputController.controllerType = ControllerType.LUNA;
      }
      if(GUILayout.Button("Keyboard Input")) {
         PlayerInputController.controllerType = ControllerType.KEYBOARD;
      }
   }
}
#endif
