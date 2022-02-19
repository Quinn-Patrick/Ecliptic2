using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMission : MonoBehaviour, IMission
{
    private MissionType _type = MissionType.Asteroids;
    private List<Asteroid> _asteroidList = new List<Asteroid>();
    private int _asteroidsDestroyed = 0;
    private int _totalAsteroids = 0;
    private string _name;
    private string _description;
    private bool _isRequired;

    [SerializeField] private AsteroidMissionData _data;

    private void Start()
    {
        _name = _data.name;
        _description = _data.description;
        _isRequired = _data.isRequired;
        foreach(GameObject a in GameObject.FindGameObjectsWithTag(_data.asteroidID))
        {
            Asteroid asteroid = a.GetComponent<Asteroid>();
            if (asteroid == null) continue;
            _asteroidList.Add(asteroid);
        }

        foreach(Asteroid a in _asteroidList)
        {
            a.Destroyed += (a) => DestroyAsteroid(a);
        }
        _totalAsteroids = _asteroidList.Count;
    }
    public void AcquireMission()
    {
        MissionCore.Instance.GainMission(this);
    }

    public void CompleteMission()
    {
        foreach (Asteroid a in _asteroidList)
        {
            a.Destroyed -= (a) => DestroyAsteroid(a);
        }
    }

    public string GetMissionProgress()
    {
        return $"{_asteroidsDestroyed} / {_totalAsteroids}";
    }

    public MissionType GetMissionType()
    {
        return _type;
    }

    private void DestroyAsteroid(Asteroid a)
    {
        _asteroidsDestroyed++;
        GameObject[] subAsteroids = a.GetSubAsteroids();
        if(subAsteroids != null && subAsteroids.Length == 2)
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
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), GetMissionProgress());
    }
}
