using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingAnim : MonoBehaviour
{
    public float endTime;
    public GameObject arm;
    public GameObject key;
    public Text useKey;
    public GameObject lockOne;
    public GameObject lockTwo;
    public AudioSource footstep;
    public AudioSource lockOpen;
    public AudioSource goodEnding;
    public GameObject black;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("BreakArm", endTime);
        Invoke("KeyUI", endTime + 4.0f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            lockOpen.Play();
            useKey.enabled = false;
            lockOne.SetActive(false);
            lockTwo.SetActive(true);
            Invoke("EndingSFX", 1.5f);
            Invoke("NextScene", 7.5f);
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
        key.SetActive(true);
    }

    void KeyUI()
    {
        useKey.enabled = true;
    }

    void EndingSFX()
    {
        black.SetActive(true);
        goodEnding.Play();
    }

    void NextScene()
    {
        SceneManager.LoadScene(5);
    }
}
