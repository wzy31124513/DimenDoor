using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLogiv : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject player_camera;

    [SerializeField]
    GameObject new_camera;

    [SerializeField]
    GameObject tips;

    [SerializeField]
    GameObject twoD;

    [SerializeField]
    GameObject door;

    [SerializeField]
    AudioClip door_sound;

    [SerializeField]
    AudioClip key_sound;


    bool first = true;
    bool canopen = false;
    void Start()
    {
        tips.SetActive(false);
        new_camera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player"&&first)
        {
            tips.SetActive(true);
            
            //Debug.Log("COLLIDE");
            if (Input.GetKeyDown(KeyCode.F))
            {
                first = false;
                Debug.Log("KEYDOWN");
                AudioSource key_audio = GetComponent<AudioSource>();
                key_audio.PlayOneShot(key_sound);
                player_camera.SetActive(false);
                new_camera.SetActive(true);
                twoD.SetActive(false);
                tips.SetActive(false);
                Animation c_animation = new_camera.GetComponent<Animation>();
                c_animation.Play();
                Invoke("opendoor", 8.0f);
                Invoke("nothing", 11.0f);
                Debug.Log("finished");
                
            }
        }
    }
    void nothing()
    {
        player_camera.SetActive(true);
        new_camera.SetActive(false);
        twoD.SetActive(true);
    }
    void opendoor()
    {
        canopen = true;
        AudioSource door_audio = door.GetComponent<AudioSource>();
        door_audio.PlayOneShot(door_sound);
    }
    private void FixedUpdate()
    {
        if(canopen && door.transform.position.y < 50.0f)
        {
            door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y + 2.0f * Time.deltaTime, door.transform.position.z);
        }
    }
}
