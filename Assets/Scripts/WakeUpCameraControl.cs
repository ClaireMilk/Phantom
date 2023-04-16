using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpCameraControl : MonoBehaviour
{
    private CinemachineBrain cinemachine;
    public float endTime;

    // Start is called before the first frame update
    void Awake()
    {
        cinemachine = GetComponent<CinemachineBrain>();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("CloseCinemachine", endTime);
    }

    private void CloseCinemachine()
    {
        cinemachine.enabled = false;
        transform.localPosition = new Vector3(0, 4.0f, 0);
    }
}
