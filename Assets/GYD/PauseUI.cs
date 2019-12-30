using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public static PauseUI pauseUI;

    bool pause = false;
    [SerializeField]
    GameObject PauseText;

    [SerializeField]
    GameObject ContinueText;

    [SerializeField]
    GameObject Panel;

    [SerializeField]
    GameObject BackText;

    [SerializeField]
    GameObject twoDsignal;
    // Start is called before the first frame update
    void Start()
    {
        pauseUI = this;
        PauseText.SetActive(false);
        ContinueText.SetActive(false);
        Panel.SetActive(false);
        BackText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }
        if (pause && Input.GetKeyDown(KeyCode.E))
        {
            pause = false;
            Debug.Log("Continue");
        }
        if (pause && Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("Opening");
            Debug.Log("Back to Main Menu");
        }
        if (pause)
        {
            Time.timeScale = 0;
            PauseText.SetActive(true);
            ContinueText.SetActive(true);
            Panel.SetActive(true);
            BackText.SetActive(true);

        }
        else
        {
            
            Time.timeScale = 1;
            PauseText.SetActive(false);
            ContinueText.SetActive(false);
            Panel.SetActive(false);
            BackText.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            blingbling();
            Debug.Log("blingbling");
        }
        
    }
    public void twoD_sign(bool sign)
    {
        if (sign)
        {
            twoDsignal.SetActive(true);
        }
        else
        {
            twoDsignal.SetActive(false);
        }
    }
    public void b()
    {
        twoDsignal.SetActive(false);
    }

    public void ling()
    {
        twoDsignal.SetActive(true);
    }
    public void blingbling()
    {
        InvokeRepeating("b", 0,1f);
        InvokeRepeating("ling",0.5f, 1f);
        Invoke("StopBling", 3.0f);
    }
    public void StopBling()
    {
        CancelInvoke();
        ling();
    }
}
