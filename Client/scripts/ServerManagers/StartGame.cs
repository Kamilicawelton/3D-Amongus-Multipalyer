using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Debug.Log("Press");
            ClientSend.PokreniIgru();
            /*foreach(PlayerManager _player in GameManager.players.Values)
            {
                _player.transform.position = new Vector3(-20f, 0f, 2f);
            }
            */
        }
    }
}
