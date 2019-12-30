using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCenterLogic : MonoBehaviour
{
    public bool rotate = false;
    float speed = 6.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void FixedUpdate()
    {
        if (rotate)
        {        
            transform.Rotate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
        }
    }
}
