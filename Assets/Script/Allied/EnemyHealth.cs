using UnityEngine;

public class EnemyHealth : MonoBehaviour
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
            winLoseHandler.OnEnemyDied();
            Destroy(gameObject);
        }
    }
}
