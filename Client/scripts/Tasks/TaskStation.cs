using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskStation : MonoBehaviour
{
    public bool _isPlayerWithinZone;
    public GameObject task;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            if (_isPlayerWithinZone)
            {
                task.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("GIT");
        if (other.tag == "player")
            _isPlayerWithinZone = true;
        Debug.Log("uso je u kocku");
        
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
            _isPlayerWithinZone = false;
            task.SetActive(false);
    }


    
}
