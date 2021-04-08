using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFramework;

public class Runner : MonoSingletonBaseAuto<Runner>{
    
    private Callback _update, _awake, _start;

    public void OnUpdate(Callback update) {
        _update += update;
    }

    public void OnAwake(Callback awake){
        _awake += awake;
    }

    public void OnStart(Callback start){
        _start = start;
    }

    private void Awake() {
        _awake();
    }

    private void Start() {
        _start();
    }

    private void Update() {
        _update();
    }
}
