using UnityEngine;

public class CamLayerControl : MonoBehaviour
{
    public GameObject CamTargetPivot;
    public int CamLevel =0;
    public Vector3 InitialPosition;
    public int OffesetJump = 20;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        CamTargetPivot.transform.position = new Vector3(InitialPosition.x, InitialPosition.y + (CamLevel * OffesetJump), InitialPosition.z);
    }
}
