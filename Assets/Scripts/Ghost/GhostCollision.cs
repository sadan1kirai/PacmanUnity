using UnityEngine;

public class GhostHit : MonoBehaviour
{
    private GhostParts parts;

    private void Awake()
    {
        parts = GetComponent<GhostParts>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            Ghost ghost = GetComponent<Ghost>();

            if (parts.ghostppe.enabled)
            {
                GameManager.Instance.GhostEaten(ghost);
            }
            else
            {
                GameManager.Instance.PacmanEaten();
            }
        }
    }
}
