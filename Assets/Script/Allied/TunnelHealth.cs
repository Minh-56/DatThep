using UnityEngine;

public class TunnelHealth : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Tunnel đã bị phá!");
            FindObjectOfType<WinLoseHandler>().OnTunnelDetected();
        }
    }
}
