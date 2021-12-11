using System.Collections.Generic;
using UnityEngine;

public class CounterEnemy : MonoBehaviour
{
    private Enemy[] _listEnemy;
    private void OnEnable()
    {
        _listEnemy = GetComponentsInChildren<Enemy>();
        //print(_listEnemy.Length);
    }
}
