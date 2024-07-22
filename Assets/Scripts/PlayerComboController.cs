using System;
using TMPro;
using UnityEngine;

public class PlayerComboController : MonoBehaviour
{
    private Rigidbody rb;
    public Material armAlpha;
    private float attackCooldown = 0.2f;
    public float lastAttackTime = 0f;
    public GameObject AtackPanel;
    public GameObject PlayerRotateY;
    public bool IsAtack;
    public float enemyDetectionRadius = 5f;
    public LayerMask enemyLayerMask;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            lastAttackTime = Time.time;

            Transform nearestEnemy = GetNearestEnemy();
            if (nearestEnemy != null)
            {

                RotateTowards(nearestEnemy.position);

            }
            else
            {
                RotateAttackPanelToCursor();
            }
        }

        if (Time.time - lastAttackTime >= attackCooldown)
        {
            AtackPanel.SetActive(false);
            armAlpha.SetFloat("_Alpha", 1);
            IsAtack = false;
        }
        else
        {
            armAlpha.SetFloat("_Alpha", 0);
            AtackPanel.SetActive(true);
            IsAtack = true;
        }

        this.GetComponent<PlayerController>().IsAtk = IsAtack;
    }

    private void RotateAttackPanelToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // mascara pra ignorar o layer player
        int layerMask = ~LayerMask.GetMask("Player");

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            Vector3 hitPoint = hit.point;
            RotateTowards(hitPoint);
        }
    }

    private Transform GetNearestEnemy()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, enemyDetectionRadius, enemyLayerMask);
        Transform nearestEnemy = null;
        float closestDistanceSqr = Mathf.Infinity;

        foreach (Collider enemy in enemies)
        {
            Vector3 directionToEnemy = enemy.transform.position - transform.position;
            float dSqrToEnemy = directionToEnemy.sqrMagnitude;
            if (dSqrToEnemy < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToEnemy;
                nearestEnemy = enemy.transform;
            }
        }

        return nearestEnemy;
    }

    private void RotateTowards(Vector3 targetPosition)
    {
        AtackPanel.transform.LookAt(targetPosition);
        Vector3 lookDir = new Vector3(targetPosition.x - transform.position.x, 0, targetPosition.z - transform.position.z);
        if (lookDir != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(lookDir);
            PlayerRotateY.transform.rotation = newRotation;
        }
    }
}
