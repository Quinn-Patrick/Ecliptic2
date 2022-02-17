using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputReader
{
    public float GetThrust();
    public float GetRotation();
    public List<bool> GetActionList();
    public bool GetAction();
    public bool GetZoom();
}
