using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFramework{
    public enum ELayer{
        Top = 1,
        Middle = 2,
        Bottom = 3
    }

    public class GUIMgr : SingletonBase<GUIMgr>{
        
        private GameObject _canvas;
        public GameObject canvas{
            get{
                if (_canvas == null){
                    _canvas = GameObject.Instantiate(Resources.Load<GameObject>("UIRoot")).transform.Find("Canvas").gameObject;
                    Init();
                }
                return _canvas;
            }
        }

        Transform top, middle, bottom;
        void Init(){
            top = canvas.transform.Find("Top");
            middle = canvas.transform.Find("Middle");
            bottom = canvas.transform.Find("Bottom");
        }


        private Dictionary<string, GameObject> panelDict = new Dictionary<string, GameObject>();

        public GameObject AddPanel(string name, ELayer layer){
            if (_canvas == null) canvas.SetActive(true);
            var go = GameObject.Instantiate(Resources.Load<GameObject>(name));
            go.name = name;
            panelDict.Add(name, go);

            switch(layer){
                case ELayer.Top:
                    go.transform.parent = top;
                    break;
                case ELayer.Middle:
                    go.transform.parent = middle;
                    break;
                case ELayer.Bottom:
                    go.transform.parent = bottom;
                    break;
            }
            
            var rect = go.transform as RectTransform;

            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
            rect.anchoredPosition3D = Vector3.zero;
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            rect.localScale = Vector3.one;

            return go;
        }

        public GameObject RemovePanel(string name){
            if (!panelDict.ContainsKey(name)) return null;
            var temp = panelDict[name];
            panelDict.Remove(name);
            GameObject.Destroy(temp);
            return temp;
        }
    }

}