using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipticTwo.Core
{
    public class Player : GravitatingBody
    {
        new private void FixedUpdate()
        {
            base.FixedUpdate();
            if(_body.velocity.magnitude > Metrics.Instance.TopSpeed)
            {
                Metrics.Instance.TopSpeed = _body.velocity.magnitude;
            }
            Metrics.Instance.DistanceTraveled += _body.velocity.magnitude * Time.fixedDeltaTime;
        }
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
    }
}
