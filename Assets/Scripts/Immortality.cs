using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Immortality", menuName = "Powerup/Immortality")]
public class Immortality : Powerup
{
    [SerializeField]
    protected PowerupStats speed;


    public float GetSpeed()
    {
        return speed.GetValue(currentLevel);
    }
}
