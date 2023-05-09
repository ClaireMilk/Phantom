using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BadEndingAnim : MonoBehaviour
{
    public float endTime;
    public GameObject arm;
    public GameObject pistol;
    public Text usePistol;
    public AudioSource footstep;
    public GameObject gunAnim;
    public GameObject newCamera;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("BreakArm", endTime);
        Invoke("KeyUI", endTime + 2.0f);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            usePistol.enabled = false;
            gunAnim.SetActive(true);
            Invoke("NextScene", 4.0f);
        }
    }

    public void Fall()
    {
        footstep.Stop();
    }

    public void BreakArm()
    {
        footstep.Play();
        arm.SetActive(true);
        pistol.SetActive(true);
    }

    void KeyUI()
    {
        newCamera.SetActive(true);
        usePistol.enabled = true;
    }

    void NextScene()
    {
        SceneManager.LoadScene(5);
    }
}

