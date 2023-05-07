using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpCameraControl : MonoBehaviour
{
    private CinemachineBrain cinemachine;
    public float endTime;
    public Transform player1;
    private Vector3 original;
    public GameObject openEyeUI;

    // Start is called before the first frame update
    void Awake()
    {
        cinemachine = GetComponent<CinemachineBrain>();
        original = new Vector3(player1.position.x, player1.position.y, player1.position.z);
        Invoke("CloseCinemachine", endTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CloseCinemachine()
    {
        player1.position = new Vector3(original.x, original.y, original.z);
        player1.localRotation = Quaternion.Euler(0, 130, 0);
        transform.localPosition = new Vector3(0, 4, 0);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        cinemachine.enabled = false;
        openEyeUI.SetActive(false);
    }
}
