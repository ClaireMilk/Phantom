using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Phantom
{
    enum E_InteractiveType
    {
        Watch,

        OtherItems,

        Files,

        DoorLeft,

        DoorRight,

        DoorLocked,

        Drawer,

        Light
    }

    public class InteractiveList : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            E_InteractiveType tagName = E_InteractiveType.Watch;
            switch (tagName)
            {
                case E_InteractiveType.Watch:
                    break;
                case E_InteractiveType.OtherItems:
                    break;
                case E_InteractiveType.Files:
                    break;
                case E_InteractiveType.DoorLeft:
                    break;
                case E_InteractiveType.DoorRight:
                    break;
                case E_InteractiveType.DoorLocked:
                    break;
                case E_InteractiveType.Drawer:
                    break;
                case E_InteractiveType.Light:
                    break;
                default:
                    break;
            }
        }
    }
}
