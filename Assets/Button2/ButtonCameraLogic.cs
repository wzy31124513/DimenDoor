using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCameraLogic : MonoBehaviour
{
    [SerializeField]
    GameObject player_camera;

    [SerializeField]
    GameObject new_camera;

    [SerializeField]
    GameObject tips;

    [SerializeField]
    GameObject twoD;

    [SerializeField]
    GameObject m_light;

    [SerializeField]
    GameObject word;

    [SerializeField]
    GameObject panel;

    bool first = true;
    bool canopen = false;
    void Start()
    {
        tips.SetActive(false);
        new_camera.SetActive(false);
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && first)
        {
            tips.SetActive(true);

            //Debug.Log("COLLIDE");
            
                Debug.Log("KEYDOWN");
                player_camera.SetActive(false);
                new_camera.SetActive(true);
                twoD.SetActive(false);
                
            if (Input.GetKeyDown(KeyCode.F))
            {
                tips.SetActive(false);
                first = false;
                Destroy(m_light);
                word.SetActive(true);
                panel.SetActive(true);
                Invoke("nothing", 2.0f);
                
            }
        }
    }
    void nothing()
    {
        player_camera.SetActive(true);
        new_camera.SetActive(false);
        twoD.SetActive(true);
        word.SetActive(false);
        panel.SetActive(false);
    }
}

