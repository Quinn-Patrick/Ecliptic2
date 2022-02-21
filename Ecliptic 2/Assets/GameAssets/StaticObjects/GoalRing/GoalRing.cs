using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Mathematics.math;

public class GoalRing : MonoBehaviour
{
    [SerializeField] private List<GameObject> goalDots = new List<GameObject>();
    private float _time = 0f;

    private void Update()
    {
        _time += Time.deltaTime * 2;
        int index = 0;
        foreach(GameObject dot in goalDots)
        {
            float offset = (float) index / goalDots.Count * 2 * PI;
            float relativeX = cos(_time + (offset)) * 0.5f;
            float relativeY = sin(_time + (offset)) * 2.0f;
            dot.transform.localPosition = new Vector2(relativeX, relativeY);
            index++;
        }
    }
}
