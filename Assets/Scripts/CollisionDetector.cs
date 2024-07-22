using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private ATKControl atkControl;
    public GameObject hitPrefab;
    private LayerMask enemyLayer;

    public void Init(ATKControl atkControl, LayerMask enemyLayer)
    {
        this.atkControl = atkControl;
        this.enemyLayer = enemyLayer;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (((1 << other.gameObject.layer) & enemyLayer) != 0)
        {
            atkControl.OnHitEnemy();
        }
    }
}
