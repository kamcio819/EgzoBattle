using System;
using UnityEngine;

public class PlayerStats : Singleton<PlayerStats>
{
    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;

    [SerializeField]
    private float health;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float maxTotalHealth = 100;

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }
    public float MaxTotalHealth { get { return maxTotalHealth; } }

    protected override void Awake()
    {
        base.Awake();
    }

    public void Heal(float health)
    {
        this.health += health;
        ClampHealth();
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        ClampHealth();
    }

    public void AddHealth()
    {
        if (maxHealth < maxTotalHealth)
        {
            maxHealth += 1;
            health = maxHealth;

            if (onHealthChangedCallback != null)
                onHealthChangedCallback.Invoke();
        }
    }

    void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke();
    }
}
