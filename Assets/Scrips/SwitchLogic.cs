using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLogic : MonoBehaviour
{
    [SerializeField]
    GameObject step_one;
    [SerializeField]
    GameObject step_two;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        step_one.transform.Rotate(new Vector3(0,90,0));
        step_two.transform.Rotate(new Vector3(0,90,0));
    }
}
