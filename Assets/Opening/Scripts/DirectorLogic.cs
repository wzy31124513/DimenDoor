using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;


public class DirectorLogic : MonoBehaviour
{
    [SerializeField]
    GameObject Director1;

    [SerializeField]
    GameObject Director2;

    [SerializeField]
    GameObject Director3;

    [SerializeField]
    GameObject Director4;

    float m_time = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        Director1.SetActive(true);
        Director2.SetActive(false);
        Director3.SetActive(false);
        Director4.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if(m_time > 31)
            if(Input.anyKeyDown)
            {
                Director1.SetActive(false);
                Director2.SetActive(true);
                Director3.SetActive(false);
                Director4.SetActive(false);
                PlayableDirector m_playableDirector = Director2.GetComponent<PlayableDirector>();
                m_playableDirector.initialTime = 43.0f;
            }
    }

    void FixedUpdate()
    {
        m_time = m_time + Time.deltaTime;
    }

    public void TurnToCredits()
    {
        Director1.SetActive(false);
        Director2.SetActive(false);
        Director3.SetActive(true);
        Director4.SetActive(false);
    }

    public void TurnBack()
    {
        PlayableDirector m_playableDirector = Director2.GetComponent<PlayableDirector>();
        m_playableDirector.initialTime = 43.0f;
        Director1.SetActive(false);
        Director2.SetActive(true);
        Director3.SetActive(false);
        Director4.SetActive(false);
    }

    public void StartGame()
    {
        Director1.SetActive(false);
        Director2.SetActive(false);
        Director3.SetActive(false);
        Director4.SetActive(true);
        //SceneManager.LoadScene("1234");
        Invoke("Load", 30.0f);
    }

    void Load()
    {
        SceneManager.LoadScene("1234");
    }

}
