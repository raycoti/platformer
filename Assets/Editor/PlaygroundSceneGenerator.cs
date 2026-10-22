using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

// Creates a new scene from the playground template: the RobotBoy controller,
// the follow camera rig, a light, a plane floor and one rotater trigger.
// The template is copied rather than rebuilt so the components added to the
// robot in the scene (Rigidbody, colliders) come along with it.
public static class PlaygroundSceneGenerator
{
    private const string k_TemplatePath = "Assets/playground.unity";

    [MenuItem("Tools/Platformer/New Playground Scene")]
    private static void CreatePlaygroundScene()
    {
        if (AssetDatabase.LoadAssetAtPath<SceneAsset>(k_TemplatePath) == null)
        {
            EditorUtility.DisplayDialog("New Playground Scene",
                "Template scene not found at " + k_TemplatePath + ".", "OK");
            return;
        }

        string path = EditorUtility.SaveFilePanelInProject("New Playground Scene",
            "newScene", "unity", "Choose where to save the new scene.", "Assets");
        if (string.IsNullOrEmpty(path))
        {
            return;
        }
        if (path == k_TemplatePath)
        {
            EditorUtility.DisplayDialog("New Playground Scene",
                "Pick a different name; that's the template itself.", "OK");
            return;
        }

        // ask to save the open scene before we switch away from it
        if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            return;
        }

        // CopyAsset fails if the destination exists, so clear it first
        // (the save panel has already asked the user to confirm overwriting)
        if (AssetDatabase.LoadAssetAtPath<SceneAsset>(path) != null)
        {
            AssetDatabase.DeleteAsset(path);
        }
        if (!AssetDatabase.CopyAsset(k_TemplatePath, path))
        {
            Debug.LogError("Couldn't copy " + k_TemplatePath + " to " + path);
            return;
        }

        EditorSceneManager.OpenScene(path);
        Debug.Log("Created playground scene at " + path);
    }
}
