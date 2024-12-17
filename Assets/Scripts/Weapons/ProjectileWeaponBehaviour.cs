using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    protected Vector3 direction;
    public float destroyAfterSeconds;
    public WeaponScriptableObject weaponData;

    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

    private void Awake()
    {
        currentDamage = weaponData.damage;
        currentSpeed = weaponData.speed;
        currentCooldownDuration = weaponData.cooldownDuration;
        currentPierce = weaponData.pierce;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }
    
    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;

        float dirx = direction.x;
        float diry = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if (dirx < 0 && diry == 0)
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
        } else if (dirx == 0 && diry < 0)
        {
            scale.y = scale.y * -1;
        } else if (dirx == 0 && diry > 0)
        {
            scale.x = scale.x - 1;
        } else if (dir.x > 0 && dir.y > 0)
        {
            rotation.z = 0f;
        } else if (dir.x > 0 && dir.y < 0)
        {
            rotation.z = -90f;
        } else if (dir.x < 0 && dir.y < 0)
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = 0f;
        }

        transform.localScale = scale;   
        transform.rotation = Quaternion.Euler(rotation); // cannot simply set vector

    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyStat enemy = collision.GetComponent<EnemyStat>();
            enemy.TakeDamage(currentDamage);
            ReducePierce();
        }
    }

    void ReducePierce()
    {
        currentPierce--;
        if (currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }
}
