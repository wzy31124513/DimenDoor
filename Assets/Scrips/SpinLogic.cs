using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinLogic : MonoBehaviour
{
    GameObject RotateCenter;
    [SerializeField]
    GameObject RotateController;
    float speed = 6.0f;
    // Start is called before the first frame update
    void Start()
    {
        RotateCenter = GameObject.FindGameObjectWithTag("RotateCenter");
    }

    private void FixedUpdate()
    {
        if (RotateCenter.GetComponent<RotateCenterLogic>().rotate)
        {
            RotateController.transform.Rotate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            RotateCenter.GetComponent<RotateCenterLogic>().rotate = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            RotateCenter.GetComponent<RotateCenterLogic>().rotate = false;
        }
    }
}
