using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ServerHandle
{
    
    public static void WelcomeReceived(int _fromClient, Packet _packet)
    {
        int _clientIdCheck = _packet.ReadInt();
        string _username = _packet.ReadString();

        Server.clientids.Add(_fromClient);

        Debug.Log($"{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {_fromClient}.");
        ServerSend.SendPlayers(_fromClient);
        Server.n_players = _fromClient;
        if (_fromClient != _clientIdCheck)
        {
            Debug.Log($"Player \"{_username}\" (ID: {_fromClient}) has assumed the wrong client ID ({_clientIdCheck})!");
        }
        Server.clients[_fromClient].SendIntoGame(_username);
        

    }

    public static void PlayerMovement(int _fromClient, Packet _packet)
    {
        bool[] _inputs = new bool[_packet.ReadInt()];
        for (int i = 0; i < _inputs.Length; i++)
        {
            _inputs[i] = _packet.ReadBool();
        }
        Quaternion _rotation = _packet.ReadQuaternion();

        Server.clients[_fromClient].player.SetInput(_inputs, _rotation);
    }



    public static void PokreniIgru(int _fromClient, Packet _packet)
    {

        ChangeScene.Promijeni();
        
        ServerSend.ImposterPacket(1);


    }

    public static void Kill(int _fromClient, Packet _packet)
    {
        
        int _id = _packet.ReadInt();
        ServerSend.Dead(_id);
        
    }

    public static void TaskRijesen(int _fromClient, Packet _packet)
    {
        
        int _id = _packet.ReadInt();
        Server.clients[_fromClient].taskovi[_id] = true;
        FullTasks.Provjera();

    }
}