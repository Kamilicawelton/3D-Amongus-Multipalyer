using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrewTask1 : MonoBehaviour
{

    public bool pregled;
    static int[] set = { 1, 2, 3 };
    static List<int> userSet = new List<int>();
    public  GameObject correct;
    public  GameObject incorrect;

    private void Start()
    {
       
    }

    public  void Check()
    {
        userSet.Add(0);
        for (int i = 0; i < 3; i++)
        {
            if (set[i] != userSet[i])
            {
                Again();
                return;

            }

        }

        ClientSend.TaskRijesen(0);
        correct.gameObject.SetActive(true);
        StartCoroutine(destroy());

    }

      void Again()
    {
       
        incorrect.gameObject.SetActive(true);
        StartCoroutine(destroy());
        userSet.Clear();
    }

    private void Update()
    {
        if (userSet.Count == 3) Check();
        

    }

    public void PrimiInput()
    {
        int broj = int.Parse(this.gameObject.transform.GetChild(0).gameObject.gameObject.GetComponent<Text>().text);
        userSet.Add(broj);

    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(3);
       

        incorrect.SetActive(false);
        correct.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


}
