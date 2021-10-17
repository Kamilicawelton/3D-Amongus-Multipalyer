using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imposter : MonoBehaviour
{

    private float[] distances;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F");
            Kill();
        }
    }
    
    public void Kill()
    {

        //dobi sve objekte sa tagom player u krugu od 1m.
        //nakon toga ubi se najblizeg
        //onda mrtav lik napravi krug od 2m za reportanje


        Vector3 center = gameObject.transform.position;
        float radius = 10f;
        



       Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        foreach (var hitCollider in hitColliders)
        {
            
            if (hitCollider.tag == "player")
            {


                PlayerManager _player = hitCollider.gameObject.transform.parent.GetComponent<PlayerManager>();
                Debug.Log("sending packet");
                ClientSend.Kill(_player.id);
                
                
                break;

            }
            
           
        }


    }
    
    
    
}
