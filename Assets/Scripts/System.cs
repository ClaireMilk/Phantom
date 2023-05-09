using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phantom
{
    public class System : MonoBehaviour
    {
        public AudioSource click;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                click.Play();
            }
        }
    }
}
