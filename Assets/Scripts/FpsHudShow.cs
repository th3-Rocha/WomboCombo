using TMPro.Examples;
using UnityEngine;

public class FpsHudShow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject FpsHud;
   
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5)) {

            FpsHud.SetActive(!FpsHud.activeSelf);
                
        }
    }
}
