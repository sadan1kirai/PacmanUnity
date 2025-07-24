using UnityEngine;

public class GhostFollow : GhostBaseState
{
    private void OnDisable()
    {
        ghost.GetComponent<GhostParts>().scatter.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        // Do nothing while the ghost is frightened
        if (node != null && enabled && !ghost.GetComponent<GhostParts>().ghostppe.enabled)
        {
            Vector2 direction = Vector2.zero;
            float minDistance = float.MaxValue;

            // Find the available direction that moves closest to pacman
            foreach (Vector2 availableDirection in node.availableDirections)
            {
                Vector3 newPosition = transform.position + new Vector3(availableDirection.x, availableDirection.y);
                float distance = (ghost.target.position - newPosition).sqrMagnitude;

                if (distance < minDistance)
                {
                    direction = availableDirection;
                    minDistance = distance;
                }
            }

            ghost.GetComponent<GhostParts>().move.SetDirection(direction);
        }
    }
}
