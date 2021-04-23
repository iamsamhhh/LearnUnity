using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFramework{
    public class Runner : MonoSingletonBaseAuto<Runner>{
        
        private Callback _update, _start, _awake;
        private bool started = false, awaken = false;

        public void SFUpdate(Callback update) {
            _update += update;
        }

        public void RemoveUpdate(Callback needToRemove){
            _update -= needToRemove;
        }

        public void SFStart(Callback start){
            _start += start;
        }

        public void SFAwake(Callback awake){
            _awake += awake;
        }

        private void Update() {

            if (!started && _start != null){
                _start();
                started = true;
            }

            if (!awaken && _awake != null){
                _awake();
                awaken = true;
            }

            if (_update == null) return;

            _update();
        }
    }
}