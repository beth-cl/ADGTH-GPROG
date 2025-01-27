using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchscenes : MonoBehaviour
{
    public static void LoadSceneName(string s_Name)
    {
        SceneManager.LoadScene(s_Name);
    }

    public static void LoadSceneIndex(int s_Index)
    {
        SceneManager.LoadScene(s_Index);
    }
}

