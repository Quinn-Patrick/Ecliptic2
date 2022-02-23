using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;

namespace EclipticTwo.Missions
{
    public class AsteroidMission : MonoBehaviour, IMission
    {
        private MissionType _type = MissionType.Asteroids;
        private List<Asteroid> _asteroidList = new List<Asteroid>();
        private int _asteroidsDestroyed = 0;
        private int _totalAsteroids = 0;
        private string _name;
        private string _description;
        private bool _isRequired;
        private bool _isComplete;

        [SerializeField] private AsteroidMissionData _data;
        private void Start()
        {
            AcquireMission();
            _name = _data.missionName;
            _description = _data.description;
            _isRequired = _data.isRequired;
            foreach (GameObject a in GameObject.FindGameObjectsWithTag(_data.asteroidID))
            {
                Asteroid asteroid = a.GetComponent<Asteroid>();
                if (asteroid == null) continue;
                _asteroidList.Add(asteroid);
            }

            foreach (Asteroid a in _asteroidList)
            {
                a.Destroyed += (a) => DestroyAsteroid(a);
            }
            _totalAsteroids = _asteroidList.Count;
        }
        private void Update()
        {
            if (!_isComplete)
            {
                if (_asteroidList.Count == 0)
                {
                    CompleteMission();
                }
            }
        }
        public void AcquireMission()
        {
            MissionCore.Instance.GainMission(this);
        }

        public void CompleteMission()
        {
            _isComplete = true;
            foreach (Asteroid a in _asteroidList)
            {
                a.Destroyed -= (a) => DestroyAsteroid(a);
            }
        }

        public string GetMissionProgress()
        {
            if (_isComplete) return $"{_name}: Complete!";
            return $"{_name}: {_totalAsteroids - _asteroidsDestroyed} Remaining";
        }

        public MissionType GetMissionType()
        {
            return _type;
        }

        private void DestroyAsteroid(Asteroid a)
        {
            _asteroidsDestroyed++;
            GameObject[] subAsteroids = a.GetSubAsteroids();
            if (subAsteroids != null && subAsteroids.Length == 2)
            {
                Asteroid ast1 = subAsteroids[0].GetComponent<Asteroid>();
                Asteroid ast2 = subAsteroids[1].GetComponent<Asteroid>();

                if (ast1 != null)
                {
                    _asteroidList.Add(ast1);
                    _totalAsteroids++;
                    ast1.Destroyed += (ast1) => DestroyAsteroid(ast1);
                }
                if (ast2 != null)
                {
                    _asteroidList.Add(ast2);
                    _totalAsteroids++;
                    ast2.Destroyed += (ast2) => DestroyAsteroid(ast2);
                }
            }
            _asteroidList.Remove(a);
            a.Destroyed -= (a) => DestroyAsteroid(a);
        }

        public string GetMissionName()
        {
            return _name;
        }

        public string GetMissionDescription()
        {
            return _description;
        }

        public bool IsRequired()
        {
            return _isRequired;
        }
        public bool IsComplete()
        {
            return _isComplete;
        }

    }
}