using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EclipticTwo.Core;
using EclipticTwo.TimingAndScoring;
using EclipticTwo.Asteroids;

namespace EclipticTwo.Missions
{
    public class AsteroidMission : Mission
    {
        [SerializeField] protected AsteroidMissionData _data;
        private List<Asteroid> _asteroidList = new List<Asteroid>();
        private int _asteroidsDestroyed = 0;
        private int _totalAsteroids = 0;
        new private void Start()
        {
            base.Start();
            InitializeData();
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
        new public void CompleteMission()
        {
            base.CompleteMission();
            foreach (Asteroid a in _asteroidList)
            {
                a.Destroyed -= (a) => DestroyAsteroid(a);
            }
        }
        override public string GetMissionProgress()
        {
            if (_isComplete) return $"{_name}: Complete!";
            return $"{_name}: {_totalAsteroids - _asteroidsDestroyed} Remaining";
        }

        private void DestroyAsteroid(Asteroid a)
        {
            _asteroidsDestroyed++;
            GameObject[] subAsteroids = a.GetSubAsteroids();
            if (subAsteroids[0] != null && subAsteroids.Length == 2)
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
        private void InitializeData()
        {
            _name = _data.missionName;
            _description = _data.description;
            _isRequired = _data.isRequired;

            _baseScore = _data.baseScore;
            _baseTimeBonus = _data.baseTimeBonus;
            _bonusTime = _data.bonusTime;
        }
    }
}