using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointLogic : MonoBehaviour
{

    [SerializeField]
    Transform BornPosition = null;

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
            GameManager.gameManager.SetBornPoint(BornPosition);
        }
    }
}
