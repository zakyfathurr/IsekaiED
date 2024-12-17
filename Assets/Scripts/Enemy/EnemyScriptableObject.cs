using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName ="EnemyScriptableObject", menuName ="ScriptableObjects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public float moveSpeed;
    public float maxHealth;
    public float damage;
        
}
