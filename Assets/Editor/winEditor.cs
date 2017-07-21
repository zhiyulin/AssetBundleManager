using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class winEditor : EditorWindow {

	[MenuItem("Window/My Window")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(winEditor));
    }

    void OnGUI() { }
}
