using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FullTasks : MonoBehaviour
{
    public static int sum;
    public static int sveukupno;
    private static int postotak;

    public static void Provjera()
    {
        sum = 0;
        sveukupno = Server.n_players * 2;

        foreach(Client _client in Server.clients.Values)
        {
            for(int i=0; i<2; i++)
            {
                if (_client.taskovi[i] == true) sum += 1;
            }
        }


        //posalji svima da updejtaju
        postotak = sum / sveukupno* 100;
        ServerSend.SendProgress(postotak);

        
    }
}
