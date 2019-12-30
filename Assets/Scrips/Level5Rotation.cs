using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rotation_Direction1
{
    ClockWise,
    Counter_Clockwise,
}

public class Level5Rotation : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    float y = 1.5f;
    float z = 2f;
    float angle = 0.0f;
    public float m_speed = 20f;
    [SerializeField]
    public Rotation_Direction1 m_direction;
    Vector3 m_pos = Vector3.zero;
    Vector3 m_posF = Vector3.zero;
    public Vector3 m_velocity;
    PlayerLogic m_playerLogic;
    Vector3 x;
    private void Start()
    {
        x = new Vector3(0, 0, transform.position.z - target.transform.position.z);
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
        Vector3 p;
        angle += Time.deltaTime * m_speed;
        if (m_direction == Rotation_Direction1.Counter_Clockwise)
        {
            p = new Vector3(0f, y * Mathf.Sin(angle * Mathf.Deg2Rad), z * Mathf.Cos(angle * Mathf.Deg2Rad));
        }
        else
        {
            p = new Vector3(0f, y * Mathf.Cos(angle * Mathf.Deg2Rad), z * Mathf.Sin(angle * Mathf.Deg2Rad));
        }
        transform.position = target.transform.position + p + x;
    }
    
}
