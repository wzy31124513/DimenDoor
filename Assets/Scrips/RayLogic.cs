using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayLogic : MonoBehaviour
{
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
    AudioClip m_AudioClip;
    AudioSource m_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        SINGLETIME = CHANGETIME / 2.0f;
        origin_y = m_ray.transform.localScale.y;
        m_AudioSource = GetComponent<AudioSource>();

    }
    private void FixedUpdate()
    {
        if(count_time < SINGLETIME)
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
