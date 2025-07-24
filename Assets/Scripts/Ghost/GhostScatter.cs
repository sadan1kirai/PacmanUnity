using UnityEngine;

public class GhostScatter : GhostBaseState
{
    private void OnDisable()
    {
        ghost.GetComponent<GhostParts>().follow.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null && enabled && !ghost.GetComponent<GhostParts>().ghostppe.enabled)
        {
            int index = Random.Range(0, node.availableDirections.Count);

            if (node.availableDirections.Count > 1 &&
                node.availableDirections[index] == -ghost.GetComponent<GhostParts>().move.direction)
            {
                index++;

                if (index >= node.availableDirections.Count)
                {
                    index = 0;
                }
            }

            ghost.GetComponent<GhostParts>().move.SetDirection(node.availableDirections[index]);
        }
    }
}
