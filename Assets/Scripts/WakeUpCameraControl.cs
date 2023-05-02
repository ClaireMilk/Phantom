using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpCameraControl : MonoBehaviour
{
    private CinemachineBrain cinemachine;
    public float endTime;
    public GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        cinemachine = GetComponent<CinemachineBrain>();
        Invoke("CloseCinemachine", endTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CloseCinemachine()
    {
        cinemachine.enabled = false;
        transform.localPosition = new Vector3(-0.46f, 4.57f, 0.06f);
        player.transform.localPosition = new Vector3(10.14f, 14f, 16.24f);
        player.transform.localRotation = Quaternion.Euler(0, 130, 0);
    }
}
