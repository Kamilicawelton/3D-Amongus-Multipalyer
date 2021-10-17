using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int id;
    public string username;
    public bool isImposter = false;
    public bool _isdead = false;

    public void assignComponent()
    {
        if(isImposter) this.gameObject.AddComponent<Imposter>();
        else this.gameObject.AddComponent<CrewMate>();
    }

    private void Start()
    {
        
        GameObject _object = GameObject.FindGameObjectWithTag("SetKasnije");
        int childCount = _object.transform.childCount;
        for(int i=0; i<childCount; i++)
        {
            _object.transform.GetChild(i).gameObject.SetActive(true);
        }
        GameObject[] sakri = GameObject.FindGameObjectsWithTag("Gasikasnije");
        foreach(GameObject _obj in sakri)
        {
            _obj.SetActive(false);
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    public void Move(Vector3 pos)
    {
        transform.position = Vector3.Lerp(transform.position, pos, 0.1f);
    }
  
}
