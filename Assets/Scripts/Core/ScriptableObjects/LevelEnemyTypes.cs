using System.Collections.Generic;
using Core.FightLogic;
using UnityEngine;

namespace Core.ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemyWave", menuName = "Create EnemyWave", order = 51)]
    public class LevelEnemyTypes : ScriptableObject
    {
        //[TableList] OdinInspector
        [SerializeField]
        public List<Fighter> EnemyTypes;

    }
}