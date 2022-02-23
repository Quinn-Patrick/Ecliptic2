using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedReadout : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _readout;
    [SerializeField] private Rigidbody2D _dataSource;
    
    void Update()
    {
        if (_dataSource == null)
        {
            _readout.text = "";
            return;
        }
        float velocity = _dataSource.velocity.magnitude;
        
        _readout.text = $"Speed: {velocity:000.0} m/s";
        return;
        
    }
}
