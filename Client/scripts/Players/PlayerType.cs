using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
public class PlayerType : MonoBehaviour
{


    public Text imposter_text;
    public Text crew_text;
    public GameObject _impostericons;
    public GameObject _crewicons;

    

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "arena")
        {
            if (GameManager.players[Client.instance.myId].isImposter == true)
            {
                imposter_text.GetComponent<Text>().enabled = true;
                _impostericons.SetActive(true);
                StartCoroutine(wait());
            }
            else
            {
                crew_text.GetComponent<Text>().enabled = true;
                _crewicons.SetActive(true);
                StartCoroutine(wait());

            }
            
            
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        Destroy(imposter_text);
        Destroy(crew_text);
        
        Destroy(this);
        
        

       
    }
    
}
