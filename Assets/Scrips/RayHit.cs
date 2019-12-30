using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.gameManager.Dead();
            //Debug.Log("Dead");
            //Destroy(other.gameObject);
        }

    }
}
