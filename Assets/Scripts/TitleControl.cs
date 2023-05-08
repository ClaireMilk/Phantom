using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class TitleControl : MonoBehaviour
{
    public GameObject title;
    public Image titleImage;
    public Image blackout;
    public Image black;

    void Start()
    {
        black.DOFade(0,1f);
        Invoke("ShowTitle", 2f);
        Invoke("Blackout", 9f);
        Invoke("ToMainMenu", 10f);
    }

    void ShowTitle()
    {
        titleImage.DOFade(1,1f);
        title.SetActive(true);
    }

    public void Blackout()
    {
        blackout.DOFade(1,1f);
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
