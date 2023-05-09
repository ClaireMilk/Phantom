using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
    public GameObject pausemenu;
    private bool ispaused;
    public Image Hands;
    public Image pauseImage;
    public Sprite realityS;
    public Sprite NightmareS;
    public Sprite handssprite;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        
        {
            if(ispaused == false)//game is runing, pressed esc
            {
                Cursor.visible = false;
                pausemenu.SetActive(true);
                Time.timeScale=0;
                ispaused=true;
                if(player.activeSelf==true){
                    if(Hands.sprite==handssprite)
                    {
                        pauseImage.sprite = realityS;
                    }else{pauseImage.sprite = NightmareS;}}
                else{pauseImage.sprite = NightmareS;}
            }else{//game is paused, pressed esc
                Cursor.visible = true;
                pausemenu.SetActive(false);
                Time.timeScale=1;
                ispaused=false;
                }
        }
    }
    public void OnResume()
    {
        
            pausemenu.SetActive(false);
            Time.timeScale=1;
            ispaused=false;
    }

    public void OnMainmenu()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}