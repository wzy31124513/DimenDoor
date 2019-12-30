using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum UIStateType
{
    MainMenu,
    Options,
    Language,
    Game
}


[System.Serializable]
public class UIState
{
    public UIStateType m_UIStateType;
    public GameObject m_GameObject;
}

public class UIClick : MonoBehaviour
{

    [SerializeField]
    List<UIState> m_UIStates = new List<UIState>();

    List<Button> m_UIButtons = new List<Button>();

    Dictionary<UIStateType, GameObject> m_UIStateDictionary = new Dictionary<UIStateType, GameObject>();
    

    AudioSource m_AudioSource;


    [SerializeField]
    GameObject DirectController;

    DirectorLogic m_DirectorLogic;
    // Start is called before the first frame update
    void Start()
    {
        foreach(UIState state in m_UIStates)
        {
            m_UIStateDictionary[state.m_UIStateType] = state.m_GameObject;
        }
        // m_UIStateDictionary[UIStateType.Options].SetActive(false);
        // m_UIStateDictionary[UIStateType.MainMenu].SetActive(true);
        m_DirectorLogic = DirectController.GetComponent<DirectorLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartClicked()
    {
        // Debug.Log("Start");

        m_DirectorLogic.StartGame();
    }

    public void OnOptionClicked()
    {
        // Debug.Log("Options");
        m_DirectorLogic.TurnToCredits();
        
    }
    
    public void OnQuitClicked()
    {
        // Debug.Log("Quit");
        Application.Quit();
    }

    
    public void OnSoundsClicked()
    {
        // Debug.Log("Sounds");
    }
    
    public void OnBackClicked()
    {
        // Debug.Log("Back");
        m_DirectorLogic.TurnBack();

    }
    
}
