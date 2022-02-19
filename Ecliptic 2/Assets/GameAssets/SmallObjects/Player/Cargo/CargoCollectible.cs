using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoCollectible : MonoBehaviour, ITriggerObject
{
    public delegate void CollectHandler(CargoCollectible cargo);
    public event CollectHandler Collected;
    [SerializeField] private CargoGrabber _grabber;
    private void Awake()
    {
        if (_grabber == null) return;
        _grabber.AddPotentialCargo(this);
    }
    public void PlayerEnter(Player player)
    {
        Collected?.Invoke(this);
    }

    public void PlayerExit(Player player){}

    public void PlayerStay(Player player){} 
}
