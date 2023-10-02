using UnityEngine;
using UnityEngine.Serialization;

public class GarbageBorder : MonoBehaviour
{
    [SerializeField] string groundTag = "Ground";
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(groundTag)) Destroy(other.gameObject);
    }
}