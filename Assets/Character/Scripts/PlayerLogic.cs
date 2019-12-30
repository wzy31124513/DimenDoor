using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

using System.IO;
using System.Linq;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    float m_horizontalInput;
    float m_verticalInput;

    float m_movementSpeed = 6.0f;

    float m_gravity = 0.981f;
    float m_jumpHeight = 0.3f;
    float m_jumpcd = 0.78f;

    Vector3 m_movementInput;
    Vector3 m_horizontalMovement;
    Vector3 m_verticalMovement;
    Vector3 m_heightMovement;

    bool m_jump = false;
    bool living = true;
    bool not_played = true;
    // bool m_isLoading = false;

    CharacterController m_characterController;

    Animator m_animator;

    AudioSource m_audioSource;

    // List<AudioClip> m_runGrassSounds = new List<AudioClip>();
    // List<AudioClip> m_runPuddleSounds = new List<AudioClip>();
    List<AudioClip> m_runStoneSounds = new List<AudioClip>();
    List<AudioClip> m_walkStoneSounds = new List<AudioClip>();
    List<AudioClip> m_jumpStoneSounds = new List<AudioClip>();


    // Start is called before the first frame update
    void Start()
    {
        m_characterController = GetComponent<CharacterController>();
        m_animator = GetComponent<Animator>();
        m_audioSource = GetComponent<AudioSource>();
        m_jumpcd = 0.0f;

        #if UNITY_EDITOR
        // m_runGrassSounds = GetAssetList<AudioClip>("Audio/Run/Grass");
        // m_runPuddleSounds = GetAssetList<AudioClip>("Audio/Run/Puddle");
        //m_runStoneSounds = GetAssetList<AudioClip>("Audio/Locomotion/Run/Stone");
        //m_walkStoneSounds = GetAssetList<AudioClip>("Audio/Locomotion/Walk/Stone");
        //m_jumpStoneSounds = GetAssetList<AudioClip>("Audio/Locomotion/Landing/Stone");
        #endif
        m_animator.SetBool("Live", true);
    }

    // Update is called once per frame
    void Update()
    {
        m_verticalInput = Input.GetAxis("Vertical");
        m_horizontalInput = Input.GetAxis("Horizontal");
        if (living)
        {
            if (Input.GetButtonDown("Jump") && m_characterController.isGrounded && m_jumpcd <= 0)
            {
                m_jumpcd = 0.78f;
                m_jump = true;
            }

            m_animator.SetFloat("HorizontalInput", m_horizontalInput);
            m_animator.SetFloat("VerticalInput", m_verticalInput);
            m_animator.SetBool("Jump", m_jump);
            m_jumpcd = m_jumpcd - Time.deltaTime;
        }
        
    }

    private void FixedUpdate()
    {
        m_animator.SetBool("Live", living);
        if (!living)
        {
            Debug.Log("Dead");
        }
        else
        {
            // m_animator.SetBool("Live", true);
            if (m_jump)
            {
                m_heightMovement.y = m_jumpHeight;
                m_jump = false;
            }

            m_heightMovement.y -= m_gravity * Time.deltaTime;

            if (m_verticalInput > 0)
            {
                m_verticalMovement = transform.forward * m_verticalInput * m_movementSpeed * Time.deltaTime;
            }
            else
            {
                m_verticalMovement = transform.forward * m_verticalInput * m_movementSpeed * Time.deltaTime * 0.3f;
            }
            m_horizontalMovement = transform.right * m_horizontalInput * m_movementSpeed * Time.deltaTime * 0.45f;

            // Apply movement
            m_characterController.Move(m_horizontalMovement + m_verticalMovement + m_heightMovement);

            if (m_characterController.isGrounded)
            {
                m_heightMovement.y = 0.0f;
            }
            //Debug.Log("Live");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Live();
            Debug.Log("Fire1");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Die();
            
            Debug.Log("Fire2");
        }
    }


    public void Save()
    {
        PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", transform.position.z);
    }

    public void Load()
    {
        // m_isLoading = true;

        float posX = PlayerPrefs.GetFloat("PlayerPosX");
        float posY = PlayerPrefs.GetFloat("PlayerPosY");
        float posZ = PlayerPrefs.GetFloat("PlayerPosZ");

        transform.position = new Vector3(posX, posY, posZ);
    }
    public void Die()
    {
        m_animator.SetTrigger("Die");
        living = false;
    }
    public void Live()
    {
        living = true;
    }

    public void PlayRunFootStepSound(int footIndex)
    {
        // // Debug.Log("Play");
        // // Left = 0, Right = 1
        // if (footIndex == 0)
        // {
        //     // RayCastTerrain(m_leftFoot.position);
        // }
        // else if (footIndex == 1)
        // {
        //     // RayCastTerrain(m_rightFoot.position);
        // }
        //PlayRandomSound(m_runStoneSounds);
        Debug.Log("m_runStoneSounds");
    }

    public void PlayWalkFootStepSound()
    {
        //PlayRandomSound(m_walkStoneSounds);
        Debug.Log("m_walkStoneSounds");
    }

    public void PlayJumpSound()
    {
        //PlayRandomSound(m_jumpStoneSounds);
        Debug.Log("m_jumpStoneSounds");
    }

    // void RayCastTerrain(Vector3 position)
    // {
    //     LayerMask layerMask = LayerMask.GetMask("Terrian");
    //     Ray ray = new Ray(position, Vector3.down);
    //     RaycastHit hit;

    //     if (Physics.Raycast(ray, out hit, layerMask))
    //     {
    //         string hitTag = hit.collider.gameObject.tag;

    //         if (hitTag == "Grass")
    //         {
    //             PlayRandomSound(m_runGrassSounds);
    //         }
    //         else if (hitTag == "Water")
    //         {
    //             PlayRandomSound(m_runPuddleSounds);
    //         }
    //         else if (hitTag == "Stone")
    //         {
    //             PlayRandomSound(m_runStoneSounds);
    //         }
    //     }
    // }

    void PlayRandomSound(List<AudioClip> audioClips)
    {
        //int soundIndex = UnityEngine.Random.Range(0, audioClips.Count);
        //if(m_audioSource && audioClips.Count > soundIndex)
        //{
        //    m_audioSource.PlayOneShot(audioClips[soundIndex]);
        //}
    }

    #if UNITY_EDITOR
        List<T> GetAssetList<T>(string path) where T : class
        {
            string[] fileEntries = Directory.GetFiles(Application.dataPath + "/" + path);

            return fileEntries.Select(fileName =>
            {
                string temp = fileName.Replace("\\", "/");
                int index = temp.LastIndexOf("/");
                string localPath = "Assets/" + path;

                if (index > 0)
                    localPath += temp.Substring(index);

                return UnityEditor.AssetDatabase.LoadAssetAtPath(localPath, typeof(T));
            })
                //Filtering null values, the Where statement does not work for all types T
                .OfType<T>()    //.Where(asset => asset != null)
                .ToList();
        }
    #endif
}
