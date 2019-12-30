using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTransfer : MonoBehaviour
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
            // other.GetComponent<PlayerLogic>().m_OnPlatform = true;
            other.transform.SetParent(transform);
            //Debug.Log(other.transform.parent);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //    other.GetComponent<PlayerLogic>().m_OnPlatform = false;
            other.transform.SetParent(null);
            other.transform.parent = null;
        }
    }
}
