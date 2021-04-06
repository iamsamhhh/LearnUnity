using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFramework;
using UnityEngine.UI;

public class GameUIController : MonoBehaviourSimplify
{
    [SerializeField]
    private Image fuel;
    [SerializeField]
    private Image health;
    Color canFlyColor;
    Color cantFlyColor;

    private void Awake()
    {
        canFlyColor = new Color(0, 218, 255, 230);
        cantFlyColor = new Color(255, 47, 0, 230);
    }
    private void Update()
    {
        GUIManager.Instance.SetSliderValue(fuel, PlayerMovement.instance.fuelAmount / 100);
        if (!PlayerMovement.instance.canFly)
        {
            fuel.color = cantFlyColor;
        }
        else
        {
            fuel.color = canFlyColor;
        }
    }
}
