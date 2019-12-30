using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4DoorLogic : MonoBehaviour
{
    bool open = false;
    float speed = 2.0f;
    [SerializeField]
    float MoveHeight = 50.0f;
    CharacterController m_characterController;
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
        if (open && transform.position.y < MoveHeight)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y+speed*Time.deltaTime,transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            open = true;
        }
    }
}
