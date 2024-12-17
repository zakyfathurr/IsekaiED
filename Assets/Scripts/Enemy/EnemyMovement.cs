using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,player.transform.position, enemyData.moveSpeed * Time.deltaTime);  
    }
}
