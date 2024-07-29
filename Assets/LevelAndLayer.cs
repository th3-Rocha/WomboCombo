using UnityEngine;

public class LevelAndLayer : MonoBehaviour
{
    public CameraChangePosition CCPostion;
    public CamLayerControl CLControl;
    public int Stage = 1;

    void Start()
    {
        
    }
    void FixedUpdate()
    {
        if(Stage < CCPostion.positions.Count)
        {
            CCPostion.targetIndex = Stage -1;
        }
        else
        {
            CCPostion.targetIndex = 5;
            CLControl.CamLevel = (Stage - CCPostion.positions.Count +1);
        }
    }
}
