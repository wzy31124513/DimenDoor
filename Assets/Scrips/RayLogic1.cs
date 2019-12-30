using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayLogic1 : MonoBehaviour
{
    //GameManager gameManager;
    [SerializeField]
    GameObject m_ray;
    [SerializeField]
    float MAXTIME = 5.0f;
    float count_time = 0.0f;
    [SerializeField]
    float CHANGETIME = 3.0f;
    float SINGLETIME;
    float origin_y;
    [SerializeField]
    float RectOffset = 10.0f;
    [SerializeField]
    AudioClip m_AudioClip;
    AudioSource m_AudioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameManager.gameManager;
        SINGLETIME = CHANGETIME / 2.0f;
        origin_y = m_ray.transform.localScale.y;
        m_AudioSource = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        if (GameManager.gameManager.cameraState == 1)
        {
            m_ray.GetComponent<BoxCollider>().center = new Vector3(RectOffset,0, 0);
        }
        else
        {
            m_ray.GetComponent<BoxCollider>().center = new Vector3(0, 0, 0);
        }
            if (count_time < SINGLETIME)
        {
            count_time += Time.deltaTime;
            m_ray.transform.localScale = new Vector3(m_ray.transform.localScale.x, origin_y * count_time / SINGLETIME, m_ray.transform.localScale.z);
        }
        else if(count_time < CHANGETIME)
        {
            count_time += Time.deltaTime;
            m_ray.transform.localScale = new Vector3(m_ray.transform.localScale.x, origin_y * (CHANGETIME - count_time) / SINGLETIME , m_ray.transform.localScale.z);
        }
        else if(count_time < MAXTIME)
        {
            count_time += Time.deltaTime;
            m_ray.SetActive(false);
        }
        else
        {
            count_time = 0;
            m_ray.SetActive(true);
            m_AudioSource.PlayOneShot(m_AudioClip);
        }
    }
 
}
