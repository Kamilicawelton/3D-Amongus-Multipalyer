using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    void Update()
    {
        this.gameObject.transform.rotation = GameManager.players[Client.instance.myId].transform.rotation;
    }
}
