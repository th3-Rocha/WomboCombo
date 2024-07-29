using UnityEngine;
using System.Collections.Generic;


[ExecuteInEditMode]

public class CameraChangePosition : MonoBehaviour
{
    public List<Transform> positions = new List<Transform>();
    public int targetIndex = 0;

    void Update()
    {
        if (targetIndex >= 0 && targetIndex < positions.Count)
        {
            transform.position = positions[targetIndex].position;
            transform.rotation = positions[targetIndex].rotation;
        }
        else
        {
            Debug.LogWarning("Target index is out of bounds!");
        }
    }
}
