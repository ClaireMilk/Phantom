using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Phantom
{
    public class InputManager : MonoBehaviour
    {
        private PlayerInput playerInput;
        private PlayerInput.PlayerActions playerMove;
        private PlayerInput.GameSystemActions systemInput;
        private PlayerMotor motor;
        private PlayerLook look;
        private bool canGamePause = true;
        public GameObject pauseUI;

        void Awake()
        {
            playerInput = new PlayerInput();
            playerMove = playerInput.Player;
            systemInput = playerInput.GameSystem;
            motor = GetComponent<PlayerMotor>();
            look = GetComponent<PlayerLook>();
        }

        private void Update()
        {
            bool isPause1 = PickUp.isPause;
            bool isPause2 = FilePick.isPause;
            PickUpPause(isPause1 || isPause2);
        }

        void FixedUpdate()
        {
            //tell playermotor to move using the value from our movement action
            motor.ProcessMove(playerMove.Movement.ReadValue<Vector2>());
        }

        private void LateUpdate()
        {
            look.ProcessLook(playerMove.Look.ReadValue<Vector2>());
        }

        public void OnEnable()
        {
            playerInput.Enable();
            systemInput.Pause.performed += GamePause;
        }

        public void OnDisable()
        {
            playerInput.Disable();
        }

        public void GamePause(InputAction.CallbackContext ctx)
        {
            if (ctx.phase == InputActionPhase.Performed && canGamePause)
            {
                playerMove.Disable();
                //pauseUI.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                canGamePause = !canGamePause;
            }
            else if(ctx.phase == InputActionPhase.Performed && !canGamePause)
            {
                playerMove.Enable();
                Cursor.lockState = CursorLockMode.Locked;
                canGamePause = !canGamePause;
                //pauseUI.SetActive(false);
            }
        }

        public void PickUpPause(bool b)
        {
            if (b)
            {
                playerMove.Disable();
            }
            else
            {
                playerMove.Enable();
            }
        }

        public void Resume()
        {
            playerMove.Enable();
            Cursor.lockState = CursorLockMode.Locked;
            canGamePause = true;
            pauseUI.SetActive(false);
        }

        public void MainMenu()
        {
            SceneManager.LoadScene(1);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
