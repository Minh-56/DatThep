using UnityEngine;

public class TunnelDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Tunnel bị Enemy phát hiện!");
            FindObjectOfType<WinLoseHandler>().OnTunnelDetected();
        }
    }
}
