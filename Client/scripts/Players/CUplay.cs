using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CUplay : MonoBehaviour
{

    private TextMeshPro _txt;

    void Update()
    {


        foreach (PlayerManager _player in GameManager.players.Values)
        {
         
            {
                if (_player.id != Client.instance.myId)
                {

                    _player.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = GameManager.colors[_player.id];
                    TextMeshPro _txt = _player.transform.GetChild(1).gameObject.GetComponent<TextMeshPro>();
                    _txt.SetText(_player.username);
                    GameObject _camera = GameManager.players[Client.instance.myId].gameObject.transform.GetChild(1).gameObject;
                    _txt.transform.rotation = _camera.transform.rotation;


                }
            }



        }
    }
}
