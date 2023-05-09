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
    public GameObject gunAniml;
    public AudioSource gunShoot;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("BreakArm", endTime);
        Invoke("KeyUI", endTime + 3.0f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            usePistol.enabled = false;
            gunAniml.SetActive(true);
            gunShoot.Play();
            Invoke("NextScene", 2.0f);
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
        usePistol.enabled = true;
    }

    void NextScene()
    {
        SceneManager.LoadScene(5);
    }
}

