using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BadEnd : MonoBehaviour
{
    private Text drinkUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y) && drinkUI.enabled)
        {
            SceneManager.LoadScene(3);
        }
    }
}
