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
        public static bool canPickup;
        public static bool canPickupWatch;
        private string currentObjectName;
        private string cabinetName;

        //open furnitures
        public static bool canOpenDrawer;
        public static bool canOpenCabinetDoor;
        public static bool canOpenCabinetDoor_R;

        // UI control
        public Text noramaltHint;

        private void Awake()
        {
            noramaltHint.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            LookAtRay();
        }

        private void LookAtRay()
        {
            bool getWatch = GetWatch.getWatch;
            bool isChecking = PickUp.canRotate;

            //create a ray from camera
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            float trueRayDistance; //when checked items, ray distance will change

            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                // ray hit normal items
                if (hit.collider.gameObject.tag == "CheckedItems")
                {
                    canPickup = true;
                    hit.collider.gameObject.GetComponent<PickUp>().enabled = true;
                    currentObjectName = hit.collider.gameObject.name;
                }
                else if (hit.collider.gameObject.tag == "Watch") // ray hit watch
                    canPickupWatch = true;
                // ray hit drawers
                else if (hit.collider.gameObject.tag == "Drawer")
                {
                    canOpenDrawer = true;
                }
                // ray hit cabinet door
                else if(hit.collider.gameObject.tag == "CabinetDoor")
                {
                    canOpenCabinetDoor = true;
                    canOpenCabinetDoor_R = false;
                    cabinetName = hit.collider.gameObject.name;
                    hit.collider.gameObject.GetComponent<CabinetDoor>().enabled = true;
                }
                else if(hit.collider.gameObject.tag == "CabinetDoor_R")
                {
                    canOpenCabinetDoor_R = true;
                    canOpenCabinetDoor = false;
                    cabinetName = hit.collider.gameObject.name;
                    hit.collider.gameObject.GetComponent<CabinetDoor>().enabled = true;
                }
                else
                {
                    canPickup = false;
                    canPickupWatch = false;
                    canOpenDrawer = false;
                    canOpenCabinetDoor = false;
                    canOpenCabinetDoor_R = false;
                    cabinetName = null;
                }
                
                if (currentObjectName != null && !isChecking)
                {
                    if(hit.collider.gameObject.tag != "CheckedItems")
                    {
                        GameObject.Find(currentObjectName).GetComponent<PickUp>().enabled = false;
                    }
                }

                if (getWatch)
                {
                    //if (canPickup || isChecking)
                    //    pickHint.enabled = true;
                    //else
                    //    pickHint.enabled = false;

                    if (canOpenCabinetDoor || canOpenCabinetDoor_R)
                        noramaltHint.enabled = true;
                    else if (canOpenDrawer)
                        noramaltHint.enabled = true;
                    else
                        noramaltHint.enabled = false;


                    if (cabinetName != null && hit.collider.gameObject.tag != "CabinetDoor")
                    {
                        GameObject[] cabinetDoor = GameObject.FindGameObjectsWithTag("CabinetDoor");
                        for (int i = 0; i < cabinetDoor.Length; i++)
                        {
                            cabinetDoor[i].GetComponent<CabinetDoor>().enabled = false;
                        }
                    }
                    else if (cabinetName != null && hit.collider.gameObject.tag != "CabinetDoor_R")
                    {
                        GameObject[] cabinetDoor = GameObject.FindGameObjectsWithTag("CabinetDoor_R");
                        for (int i = 0; i < cabinetDoor.Length; i++)
                        {
                            cabinetDoor[i].GetComponent<CabinetDoor>().enabled = false;
                        }
                    }
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
