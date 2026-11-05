
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(GeneratorScript), true)]
// This attribute specifies that this custom editor is for the GeneratorScript class and its derived classes.
public class GeneratorScriptEditor : Editor
{
    // Custom inspector for GeneratorScript and its derived classes.
    public override void OnInspectorGUI()
    {
        // Draw the default inspector for the GeneratorScript.
        DrawDefaultInspector();
        // Add some space before the button.
        EditorGUILayout.Space();

        // Preview generation is for Edit Mode only.
        using (new EditorGUI.DisabledScope(Application.isPlaying))
        {
            // Add a button to generate or refresh the preview.
            if (GUILayout.Button("Generate / Refresh Preview"))
            {
                // Get the target GeneratorScript instance.
                GeneratorScript generator =
                    // Get the target GeneratorScript instance.
                    (GeneratorScript)target;
                // Call the Generate method to create or refresh the preview.
                generator.Generate();

                // Mark the scene as dirty to ensure changes are saved.
                if (generator.gameObject.scene.IsValid())
                {
                    EditorSceneManager.MarkSceneDirty(
                        generator.gameObject.scene);
                }
            }
        }
    }
}
