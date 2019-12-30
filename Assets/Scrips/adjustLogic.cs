using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adjustLogic : MonoBehaviour
{
    [SerializeField]
    float RectOffset = -10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (GameManager.gameManager.cameraState == 1)
        {
            GetComponent<BoxCollider>().center = new Vector3(RectOffset, GetComponent<BoxCollider>().center.y, GetComponent<BoxCollider>().center.z);
        }
    }
    }
