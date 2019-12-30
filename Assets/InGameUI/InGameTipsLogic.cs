using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InGameTipsLogic : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject m_text;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            m_text.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_text.SetActive(false);
        }
    }

}
