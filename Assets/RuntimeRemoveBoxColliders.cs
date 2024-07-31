using UnityEngine;
using UnityEditor;

public class RemoveBoxCollidersEditor : MonoBehaviour
{
    [MenuItem("Tools/Remove All BoxColliders")]
    private static void RemoveAllBoxColliders()
    {
        // Get the selected GameObject in the editor
        GameObject selectedObject = Selection.activeGameObject;

        if (selectedObject == null)
        {
            Debug.LogWarning("No GameObject selected. Please select a GameObject.");
            return;
        }

        // Find all BoxCollider components in the selected GameObject and its children
        BoxCollider[] colliders = selectedObject.GetComponentsInChildren<BoxCollider>();

        // Loop through each BoxCollider and remove it
        foreach (BoxCollider collider in colliders)
        {
            Undo.DestroyObjectImmediate(collider);
        }

        Debug.Log("All BoxColliders have been removed from the selected GameObject and its children.");
    }
}
