using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door4Logic : MonoBehaviour
{
    public bool open = false;
    float speed = 2.0f;
    [SerializeField]
    float MoveHeight = 50.0f;
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
        if (open && transform.position.y < MoveHeight)
        {
            m_characterController.Move(Vector3.up * speed * Time.deltaTime);
        }
    }
}
