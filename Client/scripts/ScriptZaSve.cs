using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptZaSve : MonoBehaviour
{
    private Text _text;

    public static void UpdateProgress(int progress)
    {
        Debug.Log("Updejtan text" + progress);
    }
}
