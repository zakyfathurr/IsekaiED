using UnityEngine;

public class KnifeBehaviour : ProjectileWeaponBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * weaponData.speed * Time.deltaTime;
    }
}
