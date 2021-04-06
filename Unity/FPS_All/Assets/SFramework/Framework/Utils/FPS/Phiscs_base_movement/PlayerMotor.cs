using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFramework.FPS
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMotor : MonoBehaviour
    {
        Rigidbody rb;
        Transform tran;
        private float _speed = 4000, _maxSpeed = 10, _counter = 0.15f, _maxSlopeAngle = 35, _threshold = 0.01f, _jumpForce = 250, _extraGravity = 500, _groundExtraGravity = 10, _slidingExtraGravity = 2500;
        private bool grounded = false, sliding = false, wantToJump = false;
        private Vector3 slopeNormal;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;
            tran = transform;
        }

        private void OnCollisionStay(Collision collision)
        {
            for (int i = 0; i < collision.contactCount; i++)
            {
                Vector3 normal = collision.contacts[i].normal;
                //FLOOR
                if (Walkable(normal))
                {
                    grounded = true;
                    slopeNormal = normal;
                    CancelInvoke(nameof(SetGroundedToFalse));
                }
            }

            Invoke(nameof(SetGroundedToFalse), Time.fixedDeltaTime * 2);
        }

        public void Set(float speed, float counter, float maxSpeed, float maxSlopeAngle, float threshold, float jumpForce, float extraGravity, float groundExtraGravity, float slidingExtraGravity)
        {
            _speed = speed;
            _counter = counter;
            _maxSpeed = maxSpeed;
            _maxSlopeAngle = maxSlopeAngle;
            _threshold = threshold;
            _jumpForce = jumpForce;
            _extraGravity = extraGravity;
            _groundExtraGravity = groundExtraGravity;
            _slidingExtraGravity = slidingExtraGravity;
        }

        public void Move(float x, float y)
        {
            rb.AddForce(Vector3.down * _extraGravity * Time.fixedDeltaTime * ((!wantToJump && grounded) ? _groundExtraGravity : 1));

            Vector2 mag = FindVelRelativeToLook();

            Counter(x, y, mag);

            if (x > 0 && mag.x > _maxSpeed) x = 0;
            if (x < 0 && mag.x < -_maxSpeed) x = 0;
            if (y > 0 && mag.y > _maxSpeed) y = 0;
            if (y < 0 && mag.y < -_maxSpeed) y = 0;

            float multiplier = 1f;

            if (!grounded) multiplier = 0.5f;

            if (sliding) { multiplier = 0; rb.AddForce(Vector3.down * Time.fixedDeltaTime * _slidingExtraGravity); }
            var vDir = Vector3.ProjectOnPlane(tran.forward, slopeNormal);
            var hDir = Vector3.ProjectOnPlane(tran.right, slopeNormal);
            rb.AddForce(vDir.normalized * y * Time.fixedDeltaTime * _speed * multiplier);
            rb.AddForce(hDir.normalized * x * Time.fixedDeltaTime * _speed * multiplier);
        }

        public void Jump()
        {
            wantToJump = true;
            Invoke(nameof(SetWantToJumpToFalse), Time.fixedDeltaTime * 3);
            if (!grounded || sliding) return;
            rb.AddForce(Vector2.up * _jumpForce * 1.5f);
            rb.AddForce(slopeNormal * _jumpForce * 0.5f);
        }

        void Counter(float x, float y, Vector2 mag)
        {
            if (sliding)
            {
                rb.AddForce(-rb.velocity.normalized * _speed * Time.fixedDeltaTime * _counter);
                return;
            }
            if (grounded)
            {
                if (Mathf.Abs(mag.x) > _threshold && Mathf.Abs(x) < 0.05f || (mag.x < -_threshold && x > 0) || (mag.x > _threshold && x < 0))
                {
                    rb.AddForce(_speed * tran.transform.right * Time.fixedDeltaTime * -mag.x * _counter);
                }
                if (Mathf.Abs(mag.y) > _threshold && Mathf.Abs(y) < 0.05f || (mag.y < -_threshold && y > 0) || (mag.y > _threshold && y < 0))
                {
                    rb.AddForce(_speed * tran.transform.forward * Time.fixedDeltaTime * -mag.y * _counter);
                }
            }

            if (Mathf.Sqrt((Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.z, 2))) > _maxSpeed)
            {
                float fallspeed = rb.velocity.y;
                Vector3 n = rb.velocity.normalized * _maxSpeed;
                rb.velocity = new Vector3(n.x, fallspeed, n.z);
            }
        }

        float ySize = 1;
        public void StartSliding(float size)
        {
            if (!grounded) return;
            sliding = true;
            var tmp_scale = tran.localScale;
            tmp_scale.y = size;
            tran.localScale = tmp_scale;
        }

        public void StopSliding()
        {
            var tmp_scale = tran.localScale;
            tmp_scale.y = ySize;
            tran.localScale = tmp_scale;
            sliding = false;
        }

        public Vector2 FindVelRelativeToLook()
        {
            float lookAngle = tran.transform.eulerAngles.y;
            float moveAngle = Mathf.Atan2(rb.velocity.x, rb.velocity.z) * Mathf.Rad2Deg;

            float u = Mathf.DeltaAngle(lookAngle, moveAngle);
            float v = 90 - u;

            float magnitue = rb.velocity.magnitude;
            float yMag = magnitue * Mathf.Cos(u * Mathf.Deg2Rad);
            float xMag = magnitue * Mathf.Cos(v * Mathf.Deg2Rad);

            return new Vector2(xMag, yMag);
        }

        void SetGroundedToFalse()
        {
            grounded = false;
        }

        void SetWantToJumpToFalse()
        {
            wantToJump = false;
        }

        bool Walkable(Vector3 normal)
        {
            float angle = Vector3.Angle(Vector3.up, normal);
            return angle < _maxSlopeAngle;
        }
    }
}