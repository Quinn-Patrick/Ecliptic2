using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GravitatingBody
{
    public delegate void ImpactHandler();
    public event ImpactHandler Impacted;
    private void OnTriggerEnter2D(Collider2D other)
    {
        ITriggerObject trigger = other.gameObject.GetComponent<ITriggerObject>();
        if (trigger != null)
        {
            trigger.PlayerEnter(this);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        ITriggerObject trigger = other.gameObject.GetComponent<ITriggerObject>();
        if (trigger != null)
        {
            trigger.PlayerStay(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ITriggerObject trigger = other.gameObject.GetComponent<ITriggerObject>();
        if (trigger != null)
        {
            trigger.PlayerExit(this);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Impacted?.Invoke();
    }
}
