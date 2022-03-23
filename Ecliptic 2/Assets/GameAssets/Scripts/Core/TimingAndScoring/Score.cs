using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.TimingAndScoring
{
    public class Score : MonoBehaviour
    {
        private int _score;
        public static Score Instance;
        private float _chainBonus = 1.0f;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }
        public void GainScoreTimeBonus(int baseScore, int baseTimeBonus, float baseTime)
        {
            float completionTime = baseTime / Timer.Instance.GetLevelTime();

            float timeBonus = baseTimeBonus * completionTime;

            float floatScore = (baseScore + timeBonus) * _chainBonus;

            int score = (int)floatScore;

            GainScore(score);

            IncrementChain();
        }

        public void GainScore(int score)
        {
            _score += score;
        }

        public int GetScore()
        {
            return _score;
        }

        public string GetFormattedScore()
        {
            return $"{_score:000000000}";
        }

        public void IncrementChain()
        {
            _chainBonus += 0.1f;
        }
        public void ResetChain()
        {
            _chainBonus = 1.0f;
        }
        public string GetFormattedBonus()
        {
            return $"{_chainBonus:0.0}";
        }
        public void ResetScore()
        {
            _score = 0;
            ResetChain();
        }
    }
}