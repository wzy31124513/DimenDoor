using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
    [SerializeField]
    GameObject m_light;
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
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E)) {
            Destroy(m_light);
        }
    }
}
