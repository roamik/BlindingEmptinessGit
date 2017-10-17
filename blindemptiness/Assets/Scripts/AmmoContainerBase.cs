using UnityEngine;
using System.Collections;
[System.Serializable]
public abstract class AmmoContainerBase : Item
{
    public abstract int MaxCount { get; set; }
    public abstract int Count { get; }
}
