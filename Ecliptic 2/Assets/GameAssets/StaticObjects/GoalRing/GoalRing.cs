using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Mathematics.math;

public class GoalRing : MonoBehaviour, ITriggerObject
{
    [SerializeField] private List<GameObject> goalDots = new List<GameObject>();
    private float _time = 0f;
    private bool _cleared;

    public delegate void ClearHandler(GoalRing ring);
    public event ClearHandler Cleared;

    public void PlayerEnter(Player player)
    {
        _cleared = true;
        Cleared?.Invoke(this);
    }

    public void PlayerExit(Player player){}

    public void PlayerStay(Player player){}

    private void Update()
    {
        _time += Time.deltaTime * 2;
        int index = 0;

        if (_cleared)
        {
            foreach (GameObject dot in goalDots)
            {
                dot.transform.localScale = Vector2.zero;
            }
        }
        else
        {
            foreach (GameObject dot in goalDots)
            {
                dot.transform.localScale = Vector2.one;
                float offset = (float)index / goalDots.Count * 2 * PI;
                float relativeX = cos(_time + (offset)) * 0.5f;
                float relativeY = sin(_time + (offset)) * 2.0f;
                dot.transform.localPosition = new Vector2(relativeX, relativeY);
                index++;
            }
        }
    }
    public void UnClear()
    {
        _cleared = false;
    }
}
