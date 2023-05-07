using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phantom
{
    public class PlayerTransform : MonoBehaviour
    {
        public GameObject camera2;
        public Transform player1;
        public Transform player2;

        private void Update()
        {
            if(!camera2.activeInHierarchy)
            {
                player2.transform.position = new Vector3(player1.position.x, 1, player1.position.z);
            }
            else if (camera2.activeInHierarchy)
            {
                player1.transform.position = new Vector3(player2.position.x, 14, player2.position.z);
            }
        }
    }
}