using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level5LiftReborn : MonoBehaviour
{
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager.alive == false)
            transform.position = startPos;
    }
}
