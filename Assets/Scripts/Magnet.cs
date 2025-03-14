using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Magnet", menuName = "Powerup/Magnet")]
public class Magnet : Powerup
{
    [SerializeField]
    protected PowerupStats speed;

    [SerializeField]
    protected PowerupStats range;


    public float GetSpeed()
    {
        return speed.GetValue(currentLevel);
    }

    public float GetRange()
    {
        return range.GetValue(currentLevel);
    }
}
