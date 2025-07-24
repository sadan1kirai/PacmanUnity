using UnityEngine;

public class GhostState : MonoBehaviour
{
    private GhostParts parts;

    private void Awake()
    {
        parts = GetComponent<GhostParts>();
    }

    public void Reset(GhostBaseState initial)
    {
        parts.move.ResetState();

        parts.ghostppe.Disable();
        parts.follow.Disable();
        parts.scatter.Enable();

        if (parts.spawn != initial)
        {
            parts.spawn.Disable();
        }

        if (initial != null)
        {
            initial.Enable();
        }
    }
}
