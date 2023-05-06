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
        cinemachine.enabled = false;
        player1.position = new Vector3(original.x, original.y, original.z);
    }
}
