using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Teleport : MonoBehaviour
{
    public Transform connection;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 position = connection.position;
        position.z = other.transform.position.z;
        other.transform.position = position;
    }

}
