using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave : MonoBehaviour

{
    public EnemyBlueprint[] enemyWave;
    public int waveCount;
    public float waveRate;
}
