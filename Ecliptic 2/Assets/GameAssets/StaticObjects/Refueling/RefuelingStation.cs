using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefuelingStation : MonoBehaviour, ITriggerObject
{
    [SerializeField] private float flowRate;
    public void PlayerEnter(Player player)
    {
        return;
    }

    public void PlayerExit(Player player)
    {
        return;
    }

    public void PlayerStay(Player player)
    {
        Fuel fuelSystem = player.GetFuelSystem();
        fuelSystem.PumpFuel(flowRate);
    }
}