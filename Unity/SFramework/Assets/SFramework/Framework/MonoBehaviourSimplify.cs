using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SFramework
{
    public partial class MonoBehaviourSimplify : MonoBehaviour
    {
        
        #region Functions
        
        public void Delay(float time, Callback onEnd){
            StartCoroutine(DelayCoroutine(time, onEnd));
        }

        private IEnumerator DelayCoroutine(float time, Callback action){
            yield return new WaitForSeconds(time);

            action();
        }

        #endregion


        #region msgCenter

        #region Add event

        public static void AddEvent(string eventType, Callback callback)
        {
            MsgCenter.AddEvent(eventType, callback);
        }

        public static void AddEvent<T>(string eventType, Callback<T> callback)
        {
            MsgCenter.AddEvent(eventType, callback);
        }

        public static void AddEvent<A, B>(string eventType, Callback<A, B> callback)
        {
            MsgCenter.AddEvent(eventType, callback);
        }

        public static void AddEvent<A, B, C>(string eventType, Callback<A, B, C> callback)
        {
            MsgCenter.AddEvent(eventType, callback);
        }

        public static void AddEvent<A, B, C, D>(string eventType, Callback<A, B, C, D> callback)
        {
            MsgCenter.AddEvent(eventType, callback);
        }

        public static void AddEvent<A, B, C, D, E>(string eventType, Callback<A, B, C, D, E> callback)
        {
            MsgCenter.AddEvent(eventType, callback);
        }

        #endregion

        #region remove event

        public void RemoveEvent(string eventType, Callback callback)
        {
            MsgCenter.RemoveEvent(eventType, callback);
        }


        public void RemoveEvent<A>(string eventType, Callback<A> callback)
        {
            MsgCenter.RemoveEvent(eventType, callback);
        }


        public void RemoveEvent<A, B>(string eventType, Callback<A, B> callback)
        {
            MsgCenter.RemoveEvent(eventType, callback);
        }


        public void RemoveEvent<A, B, C>(string eventType, Callback<A, B, C> callback)
        {
            MsgCenter.RemoveEvent(eventType, callback);
        }


        public void RemoveEvent<A, B, C, D>(string eventType, Callback<A, B, C, D> callback)
        {
            MsgCenter.RemoveEvent(eventType, callback);
        }


        public void RemoveEvent<A, B, C, D, E>(string eventType, Callback<A, B, C, D, E> callback)
        {
            MsgCenter.RemoveEvent(eventType, callback);
        }

        #endregion

        #region Broadcast event

        public void BroadcastEvent(string eventType)
        {
            MsgCenter.BroadcastEvent(eventType);
        }

        public void BroadcastEvent<A>(string eventType, A arg)
        {
            MsgCenter.BroadcastEvent(eventType, arg);
        }

        public void BroadcastEvent<A, B>(string eventType, A arg1, B arg2)
        {
            MsgCenter.BroadcastEvent(eventType, arg1, arg2);
        }

        public void BroadcastEvent<A, B, C>(string eventType, A arg1, B arg2, C arg3)
        {
            MsgCenter.BroadcastEvent(eventType, arg1, arg2, arg3);
        }

        public void BroadcastEvent<A, B, C, D>(string eventType, A arg1, B arg2, C arg3, D arg4)
        {
            MsgCenter.BroadcastEvent(eventType, arg1, arg2, arg3, arg4);
        }

        public void BroadcastEvent<A, B, C, D, E>(string eventType, A arg1, B arg2, C arg3, D arg4, E arg5)
        {
            MsgCenter.BroadcastEvent(eventType, arg1, arg2, arg3, arg4, arg5);
        }

        #endregion

        #endregion


        #region Input
        /// <summary>
        /// Returns the value of the horizontal axis
        /// </summary>
        public float horizontalInput
        {
            get
            {
                return Input.GetAxis("Horizontal");
            }
        }

        /// <summary>
		/// Returns the value of the jump axis
		/// </summary>
        public float jumpInput
        {
            get
            {
                return Input.GetAxis("Jump");
            }
        }

        /// <summary>
		/// Returns the value of the vertical axis
		/// </summary>
        public float verticalInput
        {
            get
            {
                return Input.GetAxis("Vertical");
            }
        }

        private Vector2 mouseInputBase = new Vector2();
        /// <summary>
		/// Returns the value of the mouse axis
		/// </summary>
        public Vector2 mouseInput
        {
            get
            {
                mouseInputBase.x = Input.GetAxis("Mouse X");
                mouseInputBase.y = Input.GetAxis("Mouse Y");
                return mouseInputBase;
            }
        }

        #endregion


        #region Raw input

        private Vector2 mouseRawInputBase = new Vector2();
        /// <summary>
		/// Returns the value of the mouse axis with no smoothing filtering applied.
		/// </summary>
        public Vector2 mouseRawInput
        {
            get
            {
                mouseRawInputBase.x = Input.GetAxisRaw("Mouse X");
                mouseRawInputBase.y = Input.GetAxisRaw("Mouse Y");
                return mouseInputBase;
            }
        }

        /// <summary>
        /// Returns the value of the Horizontal axis with no smoothing filtering applied.
        /// </summary>
        public float horizontalRawInput
        {
            get
            {
                return Input.GetAxisRaw("Horizontal");
            }
        }

        /// <summary>
		/// Returns the value of the Jump axis with no smoothing filtering applied.
		/// </summary>
        public float jumpRawInput
        {
            get
            {
                return Input.GetAxisRaw("Jump");
            }
        }

        /// <summary>
		/// Returns the value of the Jump Vertical with no smoothing filtering applied.
		/// </summary>
        public float verticalRawInput
        {
            get
            {
                return Input.GetAxisRaw("Vertical");
            }
        }
        #endregion
    }
}