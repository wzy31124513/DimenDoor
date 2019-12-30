using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLogic : MonoBehaviour
{
    GameObject RotateCenter;
    float speed = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        RotateCenter = GameObject.FindGameObjectWithTag("RotateCenter");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (RotateCenter.GetComponent<RotateCenterLogic>().rotate == true)
        {
           transform.Rotate(Vector3.down * speed * Time.deltaTime, Space.World);
        }
    }
}
