using UnityEngine;

public class AllyHealth : MonoBehaviour
{
    public int health = 100;
    private WinLoseHandler winLoseHandler;

    void Start()
    {
        winLoseHandler = FindObjectOfType<WinLoseHandler>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            winLoseHandler.OnAllyDied(gameObject);
            Destroy(gameObject);
        }
    }
}
