using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClientHandle : MonoBehaviour
{
    
    public static int n_players;

    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        Debug.Log($"Message from server: {_msg}");
        Client.instance.myId = _myId;
        ClientSend.WelcomeReceived();

        Client.instance.udp.Connect(((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port);
    }

    public static void SpawnPlayer(Packet _packet)
    {
        int _id = _packet.ReadInt();
        string _username = _packet.ReadString();
        Vector3 _position = _packet.ReadVector3();
        Quaternion _rotation = _packet.ReadQuaternion();

        GameManager.instance.SpawnPlayer(_id, _username, _position, _rotation);
        
    }

    public static void PlayerPosition(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Vector3 _position = _packet.ReadVector3();

        GameManager.players[_id].Move(_position);
        
    }

    public static void PlayerRotation(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Quaternion _rotation = _packet.ReadQuaternion();

        GameManager.players[_id].transform.rotation = _rotation;
      
    }
    
    public static void PlayerDisconnect(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Destroy(GameManager.players[_id].gameObject);
        GameManager.players.Remove(_id);
    }

 

    public static void ChangeScene(Packet _packet)
    {
       
        SceneManager.LoadScene("arena");
       


    }
    public static void SendPlayers(Packet _packet)
    {
        n_players = _packet.ReadInt();
        UpdatePlayer.UpdateCount(n_players);


    }

    public static void ImposterPacket(Packet _packet)
    {
        PlayerManager _thisplayer = GameManager.players[Client.instance.myId];
        int _id = _packet.ReadInt();

        if (_id != Client.instance.myId) _thisplayer.isImposter = false;
        else  _thisplayer.isImposter = true;

        _thisplayer.assignComponent();
   


        
    }

    public static void Dead(Packet _packet)
    {
        
        int _id = _packet.ReadInt();
        GameManager.players[_id]._isdead = true;


        GameManager.players[_id].transform.GetChild(0).transform.GetComponent<MeshRenderer>().enabled = false;
        GameManager.players[_id].transform.GetChild(1).transform.GetComponent<MeshRenderer>().enabled = false;


        if (Client.instance.myId == _id)
        {
            GameObject.FindGameObjectWithTag("dead").GetComponent<Text>().enabled = true;
        }





    }

    public static void SendProgress(Packet _packet)
    {
        int progress = _packet.ReadInt();
        
        ScriptZaSve.UpdateProgress(progress);
    }

}