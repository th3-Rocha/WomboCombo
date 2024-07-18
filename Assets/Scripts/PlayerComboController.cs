using UnityEngine;

public class PlayerComboController : MonoBehaviour
{
    private Rigidbody rb;
    public Material armAlpha;
    private float attackCooldown = 0.5f;
    public float lastAttackTime = 0f;
    public GameObject AtackPanel;
    public GameObject PlayerRotateY;
    public bool IsAtack;
    void Start()
    {
      
       rb = GetComponent<Rigidbody>();
    }

    void Update()
    {//animator.Play("atackingPlayer");
        if (Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            lastAttackTime = Time.time;

            RotateAttackPanelToCursor();
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
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 hitPoint = hit.point;

            // Rotate the attack panel to look at the hit point
            AtackPanel.transform.LookAt(hitPoint);

            // Calculate direction to look at (ignore Y-axis)
            Vector3 lookDir = new Vector3(hitPoint.x - transform.position.x, 0, hitPoint.z - transform.position.z);

            // Rotate the player to face the direction
            if (lookDir != Vector3.zero)
            {
                Quaternion newRotation = Quaternion.LookRotation(lookDir);
                PlayerRotateY.transform.rotation = newRotation;
            }
        }
    }
}
