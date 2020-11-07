using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventManager : MonoBehaviour
{
    public abstract void Spawn(float x, float y);
    public abstract void Remove();
}
