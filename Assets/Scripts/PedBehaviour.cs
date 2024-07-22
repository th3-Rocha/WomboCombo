using UnityEngine;

public class PedBehaviour : MonoBehaviour
{
    public delegate void PedDestroyed();
    public event PedDestroyed OnDestroyed;

    void OnDestroy()
    {
        if (OnDestroyed != null)
        {
            OnDestroyed.Invoke();
        }
    }
}
