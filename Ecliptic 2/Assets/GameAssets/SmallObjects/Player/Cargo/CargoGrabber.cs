using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoGrabber : MonoBehaviour
{
    private List<CargoCollectible> _potentialCargo = new List<CargoCollectible>();
    private CargoCollectible _currentCargo = null;
    [SerializeField] private CargoRope _rope;
    private void Start()
    {
        foreach(CargoCollectible c in _potentialCargo)
        {
            c.Collected += CollectCargo;
        }
    }
    public void AddPotentialCargo(CargoCollectible cargo)
    {
        _potentialCargo.Add(cargo);
    }
    private void CollectCargo(CargoCollectible cargo)
    {
        if (_currentCargo != null) return;
        _currentCargo = cargo;
        DeactivateCargoCollectible(_currentCargo);
        _rope.gameObject.SetActive(true);
        _rope.ActivatePayload(cargo.transform);
    }
    public void UnloadCargo()
    {
        if (_currentCargo == null) return;
        _currentCargo = null;
        _rope.gameObject.SetActive(false);
    }
    public void ReturnCargo()
    {
        if (_currentCargo == null) return;
        ActivateCargoCollectible(_currentCargo);
        UnloadCargo();
    }
    private void DeactivateCargoCollectible(CargoCollectible cargo)
    {
        cargo.gameObject.SetActive(false);
        cargo.Collected -= CollectCargo;
    }
    private void ActivateCargoCollectible(CargoCollectible cargo)
    {
        cargo.gameObject.SetActive(true);
        cargo.Collected += CollectCargo;
    }
    public CargoCollectible GetCurrentCargo()
    {
        return _currentCargo;
    }
}
