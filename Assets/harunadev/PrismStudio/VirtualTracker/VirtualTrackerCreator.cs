#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using VRC.SDK3.Dynamics.Contact.Components;

public class VirtualTrackerCreator : EditorWindow
{

    public readonly string version = "1.0";

    [MenuItem("GameObject/PrismStudio VirtualTracker/0")] static void c0(MenuCommand menuCommand) { CreateTracker(0, menuCommand); }
    [MenuItem("GameObject/PrismStudio VirtualTracker/1")] static void c1(MenuCommand menuCommand) { CreateTracker(1, menuCommand); }
    [MenuItem("GameObject/PrismStudio VirtualTracker/2")] static void c2(MenuCommand menuCommand) { CreateTracker(2, menuCommand); }
    [MenuItem("GameObject/PrismStudio VirtualTracker/3")] static void c3(MenuCommand menuCommand) { CreateTracker(3, menuCommand); }
    [MenuItem("GameObject/PrismStudio VirtualTracker/4")] static void c4(MenuCommand menuCommand) { CreateTracker(4, menuCommand); }
    [MenuItem("GameObject/PrismStudio VirtualTracker/5")] static void c5(MenuCommand menuCommand) { CreateTracker(5, menuCommand); }
    [MenuItem("GameObject/PrismStudio VirtualTracker/6")] static void c6(MenuCommand menuCommand) { CreateTracker(6, menuCommand); }
    [MenuItem("GameObject/PrismStudio VirtualTracker/7")] static void c7(MenuCommand menuCommand) { CreateTracker(7, menuCommand); }
    [MenuItem("GameObject/PrismStudio VirtualTracker/8")] static void c8(MenuCommand menuCommand) { CreateTracker(8, menuCommand); }
    [MenuItem("GameObject/PrismStudio VirtualTracker/9")] static void c9(MenuCommand menuCommand) { CreateTracker(9, menuCommand); }
    
    [MenuItem("GameObject/PrismStudio VirtualTracker/More...")] 
    static void cm(MenuCommand menuCommand) 
    {
        targetMenuCommand = menuCommand;
        EditorWindow.GetWindow<VirtualTrackerCreator>("PrismStudio VirtualTrackerCreator");
    }

    static int targetIndex = 0;
    static MenuCommand targetMenuCommand;

    private void OnGUI()
    {
        minSize = new Vector2(340, 150);

        GUILayout.Space(12);

        GUILayout.BeginVertical(new GUIStyle("box"));
        GUILayout.Label(version, new GUIStyle("label") { fontSize = 16, fontStyle = FontStyle.Bold });
        GUILayout.Label("VirtualTrackerCreator Version");
        GUILayout.EndVertical();

        GUILayout.Space(12);

        targetIndex = EditorGUILayout.IntField("Tracker Index", targetIndex);

        GUILayout.FlexibleSpace();

        if (GUILayout.Button("Create", GUILayout.Height(EditorGUIUtility.singleLineHeight * 2)))
        {
            CreateTracker(targetIndex, targetMenuCommand);
            Close();
        }
    }

    static void CreateTracker(int index, MenuCommand menuCommand)
    {
        CreateTracker(index, menuCommand.context as GameObject);
    }

    static void CreateTracker(int index, GameObject parent)
    {
        GameObject go = new GameObject("VirtualTracker " + index);
        GameObjectUtility.SetParentAndAlign(go, parent);
        VRCContactSender s = go.AddComponent<VRCContactSender>();
        s.shapeType = VRC.Dynamics.ContactBase.ShapeType.Sphere;
        s.radius = 0.01f;
        s.collisionTags.Add("PrismStudio Tracker " + index);
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }


}
#endif
