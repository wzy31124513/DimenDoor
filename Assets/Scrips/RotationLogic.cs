using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLogic : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    float y = 3f;
    float x = 7.5f;
    float angle = 0.0f;
    Vector3 m_pos = Vector3.zero;
    Vector3 m_posF = Vector3.zero;
    public Vector3 m_velocity;
    PlayerLogic m_playerLogic;
    Vector3 z;
    private void Start()
    {
        z = new Vector3(0, 0, transform.position.z - target.transform.position.z);
        Vector3 TargetToThis = new Vector3(transform.position.x - target.transform.position.x, transform.position.y - target.transform.position.y, 0);
         angle = Vector3.Angle(TargetToThis, Vector3.left);
        if (transform.position.y < target.transform.position.y)
        {
            angle = -angle;
        }
        m_playerLogic = FindObjectOfType<PlayerLogic>();
    }
    private void Update()
    {
        OvalRotate();
    }

    private void FixedUpdate()
    {
        m_posF = m_pos;
        m_pos = transform.position;
        m_velocity = (m_pos - m_posF) / Time.deltaTime;
    }

    void OvalRotate()     
    {
        angle += Time.deltaTime * 20;
        Vector3 p = new Vector3( x* Mathf.Cos(angle * Mathf.Deg2Rad), y * Mathf.Sin(angle * Mathf.Deg2Rad),  0f) ;
        transform.position = target.transform.position + p + z;
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
