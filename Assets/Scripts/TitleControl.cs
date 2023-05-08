using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleControl : MonoBehaviour
{
    public GameObject title;

    void Start()
    {
        Invoke("ShowTitle", 2.0f);
        Invoke("ToMainMenu", 4.0f);
    }

    void ShowTitle()
    {
        title.SetActive(true);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
