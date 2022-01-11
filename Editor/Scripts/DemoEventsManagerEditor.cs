using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DemoEventsManager))]
public class DemoEventsManagerEditor : Editor
{
    // The various categories the editor will display the variables in
    public enum DisplayCategory
    {
        Local, Azure, AWS
    }


    public string Study;
    // The enum field that will determine what variables to display in the Inspector
    public DisplayCategory categoryToDisplay;

    // The function that makes the custom editor work
    public override void OnInspectorGUI()
    {

    EditorGUILayout.PropertyField(serializedObject.FindProperty("Study"));
    // Create a space to separate this enum popup from other variables 
    EditorGUILayout.Space(); 
    // Display the enum popup in the inspector
    categoryToDisplay = (DisplayCategory) EditorGUILayout.EnumPopup("Log to", categoryToDisplay);

    // Create a space to separate this enum popup from the other variables 
    EditorGUILayout.Space(); 
        //Switch statement to handle what happens for each category
        switch (categoryToDisplay)
        {
            case DisplayCategory.Local:
                DisplayLocalInfo(); 
                break;

            case DisplayCategory.Azure:
                DisplayAzureInfo();
                break;

            case DisplayCategory.AWS:
                DisplayAWSInfo();
                break; 

        }
        serializedObject.ApplyModifiedProperties();
    }


    //When the categoryToDisplay enum is at "Basic"
    void DisplayAzureInfo()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("ConnectionString"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("UploadFileType"));

    }

    //When the categoryToDisplay enum is at "Combat"
    void DisplayAWSInfo()
    {

    }

    //When the categoryToDisplay enum is at "Magic"
    void DisplayLocalInfo()
    {

    }
}