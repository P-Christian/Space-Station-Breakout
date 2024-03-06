using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAnimation : MonoBehaviour
{
    public void Hit()
    {
        FindAnyObjectByType<HealthBar>().TakeDamage(10);
    }
}
