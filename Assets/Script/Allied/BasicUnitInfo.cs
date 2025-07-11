using UnityEngine;

public class BasicUnitInfo : MonoBehaviour, InterfaceDamageable
{
    // role của Ally (bộ đội,du kích,...)
    public UnitKind kind = UnitKind.None;

    public int maxHp = 100;
    int currentHp;

    public float moveSpeed = 3f;

    public float hitChance = 0.75f;
    public float critChance = 0.2f;
    public int bonusDamage = 0;

    public bool canHeal = false;

    void Awake()
    {
        currentHp = maxHp;
    }

    public void takeHit(int damage)
    {
        currentHp -= damage;
        Debug.Log(name + " bi trung " + damage + ", con lai: " + currentHp);

        if (currentHp <= 0)
        {
            Debug.Log(name + " da tu tran.");
            Destroy(gameObject);
        }
    }

    public void healHp(int amount)
    {
        if (!canHeal) return;

        currentHp += amount;
        if (currentHp > maxHp)
            currentHp = maxHp;

        Debug.Log(name + " hoi " + amount + " mau. Hien tai: " + currentHp);
    }

    public int getHp()
    {
        return currentHp;
    }

    public float getSpeed()
    {
        return moveSpeed;
    }

    public float getHitChance()
    {
        return hitChance;
    }

    public float getCritChance()
    {
        return critChance;
    }

    public int getBonusDmg()
    {
        return bonusDamage;
    }

    public bool isHealer()
    {
        return canHeal;
    }
     public UnitRole Role;
}

// Enum loại quân
public enum UnitKind
{
    None,
    BoDoi,
    NamDuKich,
    NuDuKich,
    GiaoLien,
    QuanY,
    BoBinh,
    Tank
}