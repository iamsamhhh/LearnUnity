using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.UI;
using UnityEngine.AI;


namespace SFramework
{
    public partial class MonoBehaviourSimplify
    {
        /// <summary>
        /// Combine things into a array
        /// </summary>
        /// <typeparam name="T"> The type to combine and return.</typeparam>
        /// <param name="obj"> Object to combine.</param>
        /// <returns>T obj</returns>
        public T[] _<T>(params T[] obj)
        {
            return obj;
        }
    }

    public class GUIManager : MonoBehaviourSimplify
    {
        public static GUIManager Instance;
        private GUIManager(){ }

        public static GUIManager GetInstance()
        {
            return Instance;
        }


        private void Awake()
        {
            
            Instance = this;
        }


        public void SetObjects(GameObject[] gameObjectsSetToTrue, bool setTo)
        {
            foreach (GameObject go in gameObjectsSetToTrue)
            {
                go.SetActive(setTo);
            }
        }

        public void PushUp(Transform trans, int times)
        {
            var index = trans.GetSiblingIndex();
            index += times;
            trans.SetSiblingIndex(index);
        }

        public void PushToTop(Transform trans)
        {
            trans.SetAsLastSibling();
        }

        public void PushDown(Transform trans, int times)
        {
            var index = trans.GetSiblingIndex();
            index -= times;
            trans.SetSiblingIndex(index);
        }

        public void PushToBottom(Transform trans)
        {
            trans.SetAsFirstSibling();
        }

        public void AddListenerWhenClicked(Button but, UnityEngine.Events.UnityAction call)
        {
            but.onClick.AddListener(call);
        }

        public void SetSliderValue(Slider slider, float value)
        {
            slider.value = value;
        }

        public void SetSliderValue(Image image, float value)
        {
            image.fillAmount = value;
        }
    }
}
