using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4LiftLogic : MonoBehaviour
{
    [SerializeField]
    Transform MaxHeight;
    [SerializeField]
    Transform MinHeight;
    [SerializeField]
    float speed = 2.0f;
    bool lift = true;
    CharacterController m_characterController;
    // Start is called before the first frame update
    void Start()
    {
        m_characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate()
    {
        if (lift)
        {
            if (transform.position.y < MaxHeight.position.y)
            {
                m_characterController.Move(Vector3.up * speed * Time.deltaTime);
            }
            else
            {
                lift = false;
            }
        }
        else
        {
            if (transform.position.y > MinHeight.position.y)
            {
                m_characterController.Move(-Vector3.up * speed * Time.deltaTime);
            }
            else
            {
                lift = true;
            }
        }
    }
}
