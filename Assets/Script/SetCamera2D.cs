using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCamera2D : MonoBehaviour
{

    //[SerializeField]
    //public int borderState; // 0 for enter   1 for exit
    [SerializeField]
    public GameObject camera2D;


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
        if (other.tag == "Player")
        {
            /*if (borderState == 0)
            {

            }
            else if (borderState == 1)
            {

            }*/
            GameManager.gameManager.canChangeState = true;
            GameManager.gameManager.ChangeCamera2D(camera2D);
            camera2D.GetComponent<camera2DFollow>().state = 1;
            camera2D.GetComponent<camera2DFollow>().followTarget = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            /*if (borderState == 0)
            {

            }
            else if (borderState == 1)
            {

            }*/
            GameManager.gameManager.canChangeState = false;
            GameManager.gameManager.ChangeTo3D();
            camera2D.GetComponent<camera2DFollow>().state = 0;
            camera2D.GetComponent<camera2DFollow>().followTarget = null;
        }
    }
}
