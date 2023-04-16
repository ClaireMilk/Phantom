using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Phantom
{
    public class GameSystem : MonoBehaviour
    {
        public static int currentPlayingScene;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            currentPlayingScene = 1;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void CheckItemsPause()
        {

        }
    }
}
