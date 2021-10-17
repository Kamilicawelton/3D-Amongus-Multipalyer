using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class ChangeScene : MonoBehaviour
{
    
    public static void Promijeni()
    {
        SceneManager.LoadScene("arena");

       

        ServerSend.ChangeScene(Server.n_players);

        




    }
}
