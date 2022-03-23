using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;

namespace EclipticTwo.Gui
{
    public class PlanetRadarManager : MonoBehaviour
    {
        [SerializeField] private PlanetRadarObject _baseObject;
        [SerializeField] private RectTransform _map;
        private void Start()
        {
            foreach(MassiveBody m in Game.planets)
            {
                GameObject newPlanetRadarObject = Instantiate(_baseObject.gameObject);
                PlanetRadarObject newPlanetRadarComponent = newPlanetRadarObject.GetComponent<PlanetRadarObject>();
                RectTransform newTransform = newPlanetRadarObject.GetComponent<RectTransform>();
                if (newPlanetRadarObject == null || newTransform == null)
                {
                    Destroy(newPlanetRadarObject);
                    continue;
                }
                newTransform.SetParent(_map);
                newPlanetRadarComponent.SetObject(m.transform);
            }
        }
    }
}