using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftLogic : MonoBehaviour
{
    bool open = false;
    bool m_static = false;
    float speed = 2.0f;
    [SerializeField]
    float MoveHeight = 50.0f;
    CharacterController m_characterController;
    [SerializeField]
    AudioClip m_LiftSound;

    AudioSource m_AudioSource;
    //CharacterController m_PlayercharacterController;

    float init_height;
    // Start is called before the first frame update
    void Start()
    {
        m_characterController = gameObject.GetComponent<CharacterController>();
        m_AudioSource = GetComponent<AudioSource>();
        //m_PlayercharacterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        init_height = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (open)
        {
            if (transform.position.y < MoveHeight)
            {
                m_characterController.Move(Vector3.up * speed * Time.deltaTime);
                //m_PlayercharacterController.Move(Vector3.up * speed * Time.deltaTime);
            }
        }
        else
        {
            if(!m_static && transform.position.y > init_height)
            {
                m_characterController.Move(-Vector3.up * speed * Time.deltaTime);
                //m_PlayercharacterController.Move(-Vector3.up * speed * Time.deltaTime);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Invoke("up", 0.7f);
            m_AudioSource.PlayOneShot(m_LiftSound);
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_static = true;
            Invoke("down", 0.7f);
        }
    }

    private void up()
    {
        open = true;
    }

    private void down()
    {
        open = false;
        m_static = false;
    }

}
