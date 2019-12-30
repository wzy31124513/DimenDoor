using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField]
    GameObject camera3D;
    [SerializeField]
    GameObject character;
    public GameObject camera2D;

    [SerializeField]
    ParticleSystem deathFX;

    [SerializeField]
    GameObject characterMesh;
    
    public int cameraState = 0; // 0 for 3D   1 for 2D

    public bool canChangeState = false;

    public Transform bornPosition;

    public bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = this;
        canChangeState = false;
        bornPosition = transform;
    }


    bool preChangeState = false;

    // Update is called once per frame
    void Update()
    {
        if (preChangeState != canChangeState)
        {
            if (canChangeState)
            {
                PauseUI.pauseUI.b();
            }
            else
            {
                PauseUI.pauseUI.ling();
            }
            preChangeState = canChangeState;
        }

        if (Input.GetMouseButtonDown(1))
            ChangeView();
    }


    public void ChangeView()
    {
        if (!canChangeState)
        {
            PauseUI.pauseUI.blingbling();
            return;
        }

        if (cameraState == 0)
        {
            cameraState = 1;
            camera3D.SetActive(false);
            if (camera2D != null)
                camera2D.SetActive(true);
            //Debug.Log(camera2D.GetComponent<vThirdPersonCamera>());
            character.GetComponent<vThirdPersonInput>().tpCamera = camera2D.GetComponent<vThirdPersonCamera>();
            character.GetComponent<vThirdPersonInput>().customCameraState = "2D";
        }
        else if (cameraState == 1)
        {
            cameraState = 0;
            camera3D.SetActive(true);
            if (camera2D != null)
                camera2D.SetActive(false);
            character.GetComponent<vThirdPersonInput>().tpCamera = camera3D.GetComponent<vThirdPersonCamera>();
            character.GetComponent<vThirdPersonInput>().customCameraState = "3D";
        }
    }
    
    public void ChangeCamera2D(GameObject cameraChange)
    {
        camera2D = cameraChange;
    }

    public void ChangeTo3D()
    {
        cameraState = 0;
        PauseUI.pauseUI.b();
        camera3D.SetActive(true);
        if (camera2D != null)
            camera2D.SetActive(false);
        character.GetComponent<vThirdPersonInput>().tpCamera = camera3D.GetComponent<vThirdPersonCamera>();
        character.GetComponent<vThirdPersonInput>().customCameraState = "3D";
    }

    public void SetBornPoint(Transform bornPos)
    {
        bornPosition = bornPos;
    }

    //public void Reborn()

    public void Dead()
    {
        alive = false;
        Invoke("Reborn", 2.0f);
        deathFX.Play();
        character.GetComponent<vThirdPersonInput>().customCameraState = "Dead";
    }

    public void Reborn()
    {
        alive = true;
        character.GetComponent<vThirdPersonInput>().enabled = true;
        character.transform.position = bornPosition.position;
        character.transform.rotation = bornPosition.rotation;
        ChangeTo3D();
    }
}
