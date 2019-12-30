using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManager : MonoBehaviour
{
    GameManager gameManager;
    GameObject[] m_StepsList;
    int list_len = 0;
    GameObject[] m_StepsList1;
    int list_len1 = 0;
    GameObject[] m_PlatformList;
    int list_len3 = 0;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.gameManager;
        //m_playerLogic = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLogic>();
        m_StepsList = GameObject.FindGameObjectsWithTag("Step");
        m_StepsList1 = GameObject.FindGameObjectsWithTag("Step1");
        m_PlatformList = GameObject.FindGameObjectsWithTag("MovingPlatform");
        list_len = m_StepsList.Length;
        list_len1 = m_StepsList1.Length;
        list_len3 = m_PlatformList.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.cameraState == 1)
        {
            for (i = 0; i < list_len; i++)
            {
                Vector3 m_tmpvec = m_StepsList[i].GetComponent<BoxCollider>().size;
                m_StepsList[i].GetComponent<BoxCollider>().size = new Vector3(30, m_tmpvec.y, m_tmpvec.z);
                //m_StepsList[i].GetComponent<BoxCollider>().size =new Vector3(10,0.25f,2.5f);
            }
            for (i = 0; i < list_len1; i++)
            {
                m_StepsList1[i].GetComponent<BoxCollider>().size = new Vector3(2.5f, 10, 2.5f);
            }
            for (i = 0; i < list_len3; i++)
            {
                m_PlatformList[i].GetComponent<BoxCollider>().size = new Vector3(50f, m_PlatformList[i].GetComponent<BoxCollider>().size.y, m_PlatformList[i].GetComponent<BoxCollider>().size.z);
            }
        }
        else
        {
            for (i = 0; i < list_len; i++)
            {
                Vector3 m_tmpvec = m_StepsList[i].GetComponent<BoxCollider>().size;
                m_StepsList[i].GetComponent<BoxCollider>().size = new Vector3(2.5f, m_tmpvec.y, m_tmpvec.z);
                //m_StepsList[i].GetComponent<BoxCollider>().size = new Vector3(2.5f, 0.25f, 2.5f);
            }
            for (i = 0; i < list_len1; i++)
            {
                m_StepsList1[i].GetComponent<BoxCollider>().size = new Vector3(2.5f, 0.25f, 2.5f);
            }
            for (i = 0; i < list_len3; i++)
            {
                m_PlatformList[i].GetComponent<BoxCollider>().size = new Vector3(5f / (m_PlatformList[i].GetComponent<Transform>().localScale.x), m_PlatformList[i].GetComponent<BoxCollider>().size.y, m_PlatformList[i].GetComponent<BoxCollider>().size.z);
            }

        }
    }
}
