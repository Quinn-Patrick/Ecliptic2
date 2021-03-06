using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EclipticTwo.Core;

namespace EclipticTwo.Gui
{

    public class DamageReadout : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _readout;
        [SerializeField] private HealthSystem _dataSource;

        void Update()
        {
            if (_dataSource == null) _readout.text = "";
            float healthPercentage = _dataSource.GetHealthPercentage();
            if (healthPercentage > 0)
            {
                _readout.text = $"Damage: {100 - (_dataSource.GetHealthPercentage() * 100):00.0}%";
                return;
            }
            _readout.text = $"Damage: Terminal";
        }
    }
}