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
        public static bool canPickupWatch;

        //open furnitures
        public static bool openDrawer;

        private void Awake()
        {
            pickHint.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            LookAtRay();

            if (GameObject.FindGameObjectWithTag("Watch") == null)
            {
                pickHint.enabled = canPickup;
            }
        }

        private void LookAtRay()
        {
            //create a ray from camera
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            float trueRayDistance; //when checked items, ray distance will change

            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                if (hit.collider.gameObject.CompareTag("checkedItems"))
                {
                    canPickup = true;
                    hit.collider.gameObject.GetComponent<PickUp>().enabled = true;
                }
                else if (hit.collider.gameObject.CompareTag("Watch"))
                    canPickupWatch = true;
                else if (hit.collider.gameObject.CompareTag("Drawer"))
                    openDrawer = true;
                else
                {
                    canPickup = false;
                    canPickupWatch = false;
                    //for (int i = 0; i < checkedObjects.Length; i++)
                    //{
                    //    checkedObjects[i].GetComponent<PickUp>().enabled = false;
                    //}
                }
            }

            if (hit.collider == null)
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
