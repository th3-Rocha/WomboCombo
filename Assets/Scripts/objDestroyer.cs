using UnityEngine;

public class ObjDestroyer : MonoBehaviour
{
    void Start()
    {
      
    }

   
    void Update()
    {
       
    }
    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
