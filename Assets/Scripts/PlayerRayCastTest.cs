using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Phantom
{
    public class PlayerRayCastTest : MonoBehaviour
    {
        public float rayDistance;
        public Color rayColor = Color.red;
        public Text pickHint;
        public static bool canPickup;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            LookAtRay();

            bool getWatch = GetWatch.getWatch;
            if (getWatch)
                pickHint.enabled = canPickup;
            else
                pickHint.enabled = false;
        }

        private void LookAtRay()
        {
            //create a ray from camera
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            float trueRayDistance; //when checked items, ray distance will change

            if (Physics.Raycast(ray, out hit, rayDistance) && hit.collider.gameObject.CompareTag("checkedItems"))
                canPickup = true;
            else if (Physics.Raycast(ray, out hit, rayDistance) && hit.collider.gameObject.CompareTag("Watch"))
                canPickup = true;
            else
                canPickup = false;

            if(hit.collider == null)
            {
                trueRayDistance = rayDistance;
            }
            else
            {
                //distance between camera and items
                trueRayDistance = Vector3.Distance(transform.position, hit.collider.transform.position);
            }

            Debug.DrawRay(ray.origin, transform.forward * trueRayDistance, rayColor);
        }
    }
}
