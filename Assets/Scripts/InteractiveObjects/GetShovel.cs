using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phantom
{
    public class GetShovel : MonoBehaviour
    {
        public static bool getShovel;
        public AudioSource shovel;

        // Update is called once per frame
        void Update()
        {
            bool canTake = PlayerRayCastTest.canTakeShovel;
            if(Input.GetKeyDown(KeyCode.E) && canTake)
            {
                shovel.Play();
                getShovel = true;
                Destroy(gameObject);
            }
        }
    }
}
