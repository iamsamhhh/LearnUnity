using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFramework.Utils.PhisicsBaseMovement
{
    public enum EMode
    {
        debuging, publishing
    }

    [RequireComponent(typeof(PlayerMotor))]
    [RequireComponent(typeof(PlayerRotate))]
    public class PlayerController : MonoBehaviourSimplify
    {
        public float speed = 4000, maxSpeed = 10, counter = 0.15f, maxSlopeAngle = 35, threshold = 0.01f, jumpForce = 250, extraGravity = 500, mouseSensitivity = 10, groundExtraGravity = 10, slidingExtraGravity = 2500;
        PlayerMotor motor;
        PlayerRotate rotate;
        public EMode mode = EMode.publishing;

        // Start is called before the first frame update
        private void Start()
        {
            motor = GetComponent<PlayerMotor>();
            rotate = GetComponent<PlayerRotate>();
            rotate.Set(-90, 90);
            motor.Set(speed, counter, maxSpeed, maxSlopeAngle, threshold, jumpForce, extraGravity, groundExtraGravity, slidingExtraGravity);

        }

        private void Update()
        {
            if (Input.GetButtonDown("Jump")) motor.Jump();
            if (Input.GetKeyDown(KeyCode.LeftShift)) motor.StartSliding(0.5f);
            if (Input.GetKeyUp(KeyCode.LeftShift)) motor.StopSliding(); ;
            Rotate();
        }

        private void FixedUpdate()
        {
            Move();
        }

        void Move()
        {
            switch (mode)
            {
                case EMode.debuging:
                    motor.Set(speed, counter, maxSpeed, maxSlopeAngle, threshold, jumpForce, extraGravity, groundExtraGravity, slidingExtraGravity);
                    break;
            }

            motor.Move(horizontalRawInput, verticalRawInput);
        }

        void Rotate()
        {

            rotate.Rotate(mouseInput * mouseSensitivity);
        }
    }
}