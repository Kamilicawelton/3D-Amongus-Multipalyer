using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdatePlayer : MonoBehaviour
{
    public static Text txt;


    private void Start()
    {
        txt = GameObject.FindGameObjectWithTag("text").GetComponent<Text>();
    }
    

    public static void UpdateCount(int n_players)
    {
        txt.GetComponent<UnityEngine.UI.Text>().text = n_players.ToString();
    }
}
