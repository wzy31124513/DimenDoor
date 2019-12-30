using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownLogic : MonoBehaviour
{
    bool open = false;
    Door4Logic door4Logic1;
    Door4Logic door4Logic2;
    [SerializeField]
    GameObject m_door1;
    [SerializeField]
    GameObject m_door2;
    //bool m_static = false;
    public float speed = 1.5f;
    [SerializeField]
    float MoveHeight = -10.0f;
    CharacterController m_characterController;
    float init_height;
    // Start is called before the first frame update
    void Start()
    {
        m_characterController = gameObject.GetComponent<CharacterController>();
        init_height = transform.position.y;
        door4Logic1 = m_door1.GetComponent<Door4Logic>();
        door4Logic2 = m_door2.GetComponent<Door4Logic>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (open)
        {
            if (transform.position.y > MoveHeight)
            {
                m_characterController.Move(-Vector3.up * speed * Time.deltaTime);
            }
        }
        else
        {
            if (transform.position.y < init_height)
            {
                m_characterController.Move(Vector3.up * speed * Time.deltaTime);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            door4Logic1.open = true;
            door4Logic2.open = true;
            Invoke("down", 0.7f);
            other.transform.SetParent(transform);
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //m_static = true;

            Invoke("up", 0.7f);

            other.transform.SetParent(null);
            other.transform.parent = null;
        }
    }

    private void up()
    {
        open = false;
        //m_static = false;
    }

    private void down()
    {
        open = true;


    }

}
