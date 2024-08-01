using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    bool isGrounded = false;
    Animator animator;
    public float teleportCooldown = 0.5f; // Cooldown in seconds
    private float nextTeleportTime = 0f;
    private Vector3 targetPosition;
    public AudioClip TpAudio;
    private AudioSource audioS;
    public GameObject tpEffect;
    public GameObject playerPivotRotate;
    public bool IsAtk;
    private PlayerComboController playerComboController;
    public CamShake camShake;
    public bool TpNow;
    public bool EnemieNearby = false;
    public GameObject tpOverlay3d;
    public bool showTpOverlay;
    public Transform StartPos;
    public bool InMoon;
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        playerComboController = GetComponent<PlayerComboController>();

        if(InMoon) {
            animator.SetBool("moon", true);
            camShake.TriggerHardShake();
            animator.Play("PlayerTeleport");
            audioS.PlayOneShot(TpAudio);
        }
        else
        {
            targetPosition = StartPos.position;
            TeleportPlayerToStoredPosition();
        }
    }

    void Update()
    {
        if (!InMoon) {


            if (Time.time >= nextTeleportTime)
            {
                tpEffect.SetActive(false);

            }
            if (Input.GetMouseButtonDown(1) && Time.time >= nextTeleportTime && !InMoon)
            {
                playerComboController.lastAttackTime = 0;
                StoreMousePosition();
                TeleportPlayerToStoredPosition();
                nextTeleportTime = Time.time + teleportCooldown;

            }
            if (IsAtk)
            {
                rb.useGravity = true;
                animator.Play("atackingPlayer");
                animator.SetBool("atk", true);
            }
            else
            {
                animator.SetBool("atk", false);
                rb.useGravity = true;
            }

            if (TpNow)
            {
                playerComboController.lastAttackTime = 0;
                TeleportPlayerToStoredPosition();
                nextTeleportTime = Time.time + teleportCooldown;
                camShake.TriggerSoftShake();
                TpNow = false;
            }

            animator.SetBool("isGrounded", isGrounded);
            if (showTpOverlay)
            {
                StoreMousePosition();
                tpOverlay3d.transform.position = targetPosition;

            }

        }
        else
        {
            
        }
       
    }

    void StoreMousePosition()
    {
       

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // mascara pra ignorar o layer player
        int layerMask = ~LayerMask.GetMask("Player");

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            targetPosition = hit.point;
        }
    }


    void TeleportPlayerToStoredPosition()
    {
        animator.Play("PlayerTeleport");
        audioS.PlayOneShot(TpAudio);
        camShake.TriggerSoftShake();
        if (EnemieNearby)
        {
            playerComboController.RotateTowardsEnemy();


        }
        else
        {
            if (targetPosition.x > 0)
            {

                playerPivotRotate.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            }
            else if (targetPosition.x < 0)
            {
                playerPivotRotate.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            }
        }
        rb.MovePosition(targetPosition);
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        tpEffect.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            TpNow = true;
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
