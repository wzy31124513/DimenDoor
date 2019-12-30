using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1Logic : MonoBehaviour
{
    bool open = false;
    float speed = 2.0f; 
    [SerializeField]
    float MoveHeight = 50.0f;
    [SerializeField]
    AudioClip m_OpenSound;
    AudioSource m_Audiosource;
    CharacterController m_characterController;
    // Start is called before the first frame update
    void Start()
    {
        m_characterController = gameObject.GetComponent<CharacterController>();
        m_Audiosource = GetComponent<AudioSource>();
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            open = true;
            m_Audiosource.PlayOneShot(m_OpenSound);
        }
    }
}
