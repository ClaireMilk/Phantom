using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BadEnd : MonoBehaviour
{
    private Text drinkUI;
    public GameObject bottle;
    public GameObject otherE;
    private Text otherUI;


    private void Start()
    {
        drinkUI = GetComponent<Text>();
        otherUI = otherE.GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y) && drinkUI.enabled)
        {
            // add sound
            Destroy(gameObject);
            Destroy(bottle);
            drinkUI.enabled = false;
            Invoke("Ending", 2.0f);
        }

        if (drinkUI.enabled)
        {
            otherUI.enabled = false;
        }
    }

    void Ending()
    {
        SceneManager.LoadScene(3);
    }
}