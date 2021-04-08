using System.Collections.Generic;
using System;

namespace SFramework
{
    public class MsgCenter
    {
        private static Dictionary<string, Delegate> messageTable = new Dictionary<string, Delegate>();

        #region add event

        // checking
        private static void AddEventCheck(string eventType, Delegate callback)
        {
            if (!messageTable.ContainsKey(eventType))
            {
                messageTable.Add(eventType, null);
            }
            Delegate d = messageTable[eventType];

            if (d != null && d.GetType() != callback.GetType())
            {
                throw new Exception(string.Format("尝试为事件{0}添加不同类型的委托，当前事件对应的类型为{1}，要添加的委托类型为{2}", eventType, d.GetType(), callback.GetType()));
            }
        }

        // no parameters
        public static void AddEvent(string eventType, Callback callback)
        {
            AddEventCheck(eventType, callback);
            messageTable[eventType] = (Callback)messageTable[eventType] + callback;
        }

        // one parameters
        public static void AddEvent<T>(string eventType, Callback<T> callback)
        {
            AddEventCheck(eventType, callback);
            messageTable[eventType] = (Callback<T>)messageTable[eventType] + callback;
        }

        // two parameters
        public static void AddEvent<A, B>(string eventType, Callback<A, B> callback)
        {
            AddEventCheck(eventType, callback);
            messageTable[eventType] = (Callback<A, B>)messageTable[eventType] + callback;
        }

        // three parameters
        public static void AddEvent<A, B, C>(string eventType, Callback<A, B, C> callback)
        {
            AddEventCheck(eventType, callback);
            messageTable[eventType] = (Callback<A, B, C>)messageTable[eventType] + callback;
        }

        // four parameters
        public static void AddEvent<A, B, C, D>(string eventType, Callback<A, B, C, D> callback)
        {
            AddEventCheck(eventType, callback);
            messageTable[eventType] = (Callback<A, B, C, D>)messageTable[eventType] + callback;
        }

        // five parameters
        public static void AddEvent<A, B, C, D, E>(string eventType, Callback<A, B, C, D, E> callback)
        {
            AddEventCheck(eventType, callback);
            messageTable[eventType] = (Callback<A, B, C, D, E>)messageTable[eventType] + callback;
        }

        #endregion

        #region Remove event

        // Check befor removing
        private static void RemoveEventCheck(string eventType, Delegate callback)
        {
            if (messageTable.ContainsKey(eventType))
            {
                Delegate d = messageTable[eventType];

                if (d == null)
                {
                    throw new Exception(string.Format("该事件{0}没有委托，无法移除", eventType));
                }
                else if (d.GetType() != callback.GetType())
                {
                    throw new Exception(string.Format("该事件{0}的委托{1}，与要移除的委托{2}类型不一致，无法移除", eventType, d.GetType(), callback.GetType()));
                }

            }
            else
            {
                throw new Exception(string.Format("事件{0}不存在", eventType));
            }
        }

        // Check after removed
        private static void CheckAfterRemoved(string eventType)
        {
            if (messageTable[eventType] == null)
            {
                messageTable.Remove(eventType);
            }
        }

        // no parameters
        public static void RemoveEvent(string eventType, Callback callback)
        {
            RemoveEventCheck(eventType, callback);
            messageTable[eventType] = (Callback)messageTable[eventType] - callback;
            CheckAfterRemoved(eventType);
        }

        // one parameters
        public static void RemoveEvent<A>(string eventType, Callback<A> callback)
        {
            RemoveEventCheck(eventType, callback);
            messageTable[eventType] = (Callback<A>)messageTable[eventType] - callback;
            CheckAfterRemoved(eventType);
        }

        // two parameters
        public static void RemoveEvent<A, B>(string eventType, Callback<A, B> callback)
        {
            RemoveEventCheck(eventType, callback);
            messageTable[eventType] = (Callback<A, B>)messageTable[eventType] - callback;
            CheckAfterRemoved(eventType);
        }

        // three parameters
        public static void RemoveEvent<A, B, C>(string eventType, Callback<A, B, C> callback)
        {
            RemoveEventCheck(eventType, callback);
            messageTable[eventType] = (Callback<A, B, C>)messageTable[eventType] - callback;
            CheckAfterRemoved(eventType);
        }

        // four parameters
        public static void RemoveEvent<A, B, C, D>(string eventType, Callback<A, B, C, D> callback)
        {
            RemoveEventCheck(eventType, callback);
            messageTable[eventType] = (Callback<A, B, C, D>)messageTable[eventType] - callback;
            CheckAfterRemoved(eventType);
        }

        // five parameters
        public static void RemoveEvent<A, B, C, D, E>(string eventType, Callback<A, B, C, D, E> callback)
        {
            RemoveEventCheck(eventType, callback);
            messageTable[eventType] = (Callback<A, B, C, D, E>)messageTable[eventType] - callback;
            CheckAfterRemoved(eventType);
        }

        #endregion

        #region Broadcast event

        public static void BroadcastEvent(string eventType)
        {
            Delegate d;

            if (messageTable.TryGetValue(eventType, out d))
            {
                Callback callback = d as Callback;

                if (d != null)
                {
                    callback();
                }
                else
                {
                    throw new Exception(string.Format("委托与该事件{0}的类型不统一，无法广播", eventType));
                }
            }
        }

        public static void BroadcastEvent<A>(string eventType, A arg)
        {
            Delegate d;

            if (messageTable.TryGetValue(eventType, out d))
            {
                Callback<A> callback = d as Callback<A>;

                if (d != null)
                {
                    callback(arg);
                }
                else
                {
                    throw new Exception(string.Format("委托与该事件{0}的类型不统一，无法广播", eventType));
                }
            }
        }

        public static void BroadcastEvent<A, B>(string eventType, A arg1, B arg2)
        {
            Delegate d;

            if (messageTable.TryGetValue(eventType, out d))
            {
                Callback<A, B> callback = d as Callback<A, B>;

                if (d != null)
                {
                    callback(arg1, arg2);
                }
                else
                {
                    throw new Exception(string.Format("委托与该事件{0}的类型不统一，无法广播", eventType));
                }
            }
        }

        public static void BroadcastEvent<A, B, C>(string eventType, A arg1, B arg2, C arg3)
        {
            Delegate d;

            if (messageTable.TryGetValue(eventType, out d))
            {
                Callback<A, B, C> callback = d as Callback<A, B, C>;

                if (d != null)
                {
                    callback(arg1, arg2, arg3);
                }
                else
                {
                    throw new Exception(string.Format("委托与该事件{0}的类型不统一，无法广播", eventType));
                }
            }
        }

        public static void BroadcastEvent<A, B, C, D>(string eventType, A arg1, B arg2, C arg3, D arg4)
        {
            Delegate d;

            if (messageTable.TryGetValue(eventType, out d))
            {
                Callback<A, B, C, D> callback = d as Callback<A, B, C, D>;

                if (d != null)
                {
                    callback(arg1, arg2, arg3, arg4);
                }
                else
                {
                    throw new Exception(string.Format("委托与该事件{0}的类型不统一，无法广播", eventType));
                }
            }
        }

        public static void BroadcastEvent<A, B, C, D, E>(string eventType, A arg1, B arg2, C arg3, D arg4, E arg5)
        {
            Delegate d;

            if (messageTable.TryGetValue(eventType, out d))
            {
                Callback<A, B, C, D, E> callback = d as Callback<A, B, C, D, E>;

                if (d != null)
                {
                    callback(arg1, arg2, arg3, arg4, arg5);
                }
                else
                {
                    throw new Exception(string.Format("委托与该事件{0}的类型不统一，无法广播", eventType));
                }
            }
        }

        #endregion
        
    }

}