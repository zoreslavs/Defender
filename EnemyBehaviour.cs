using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float health;
    public float speed;
    public float distance;
    public GameObject healthBar;
    public GameObject hitEffect;
    public GameObject destroyEffect;

    private Color enemyColor;
    private float startHealth;
    private float curDistance;
    private bool isMoving = true;
    private bool isSlowTime = false;

    void Start()
    {
        startHealth = health;
        enemyColor = GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        if (health == 0)
        {
            ShowDestroyEffect();
            Destroy(gameObject);
            return;
        }

        if (isMoving)
            Move();
    }

    public void HandleHit(Vector3 position, float damage)
    {
        health -= damage;
        if (health < 0)
            health = 0;

        if (health > 0)
        {
            ShowHitEffect(position);
        }

        healthBar.GetComponent<HealthBarBehaviour>().UpdateSize(health / startHealth);
    }

    public void SlowTime(bool value)
    {
        if (isSlowTime == value)
            return;

        isSlowTime = value;
    }

    private void Move()
    {
        float curSpeed = (isSlowTime) ? speed * 0.5f : speed;
        Vector2 step = Vector2.down * curSpeed * Time.deltaTime;
        curDistance += Mathf.Abs(step.y);
        transform.Translate(step);

        if (curDistance >= distance)
        {
            isMoving = false;
        }
    }

    private void ShowHitEffect(Vector3 position)
    {
        GameObject effect = Instantiate(hitEffect, position, Quaternion.identity);

        ParticleSystem.MainModule ma = effect.GetComponent<ParticleSystem>().main;
        ma.startColor = enemyColor;
    }

    private void ShowDestroyEffect()
    {
        GameObject effect = Instantiate(destroyEffect, transform.position, Quaternion.identity);

        ParticleSystem.MainModule ma = effect.GetComponent<ParticleSystem>().main;
        ma.startColor = enemyColor;
    }
}