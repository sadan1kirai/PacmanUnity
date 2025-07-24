using System.Collections;
using UnityEngine;

public class GhostSpawn : GhostBaseState
{
    public Transform inside;
    public Transform outside;

    private void OnEnable()
    {
        StopAllCoroutines();
    }

    private void OnDisable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(ExitTransition());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enabled && collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            var parts = ghost.GetComponent<GhostParts>();
            parts.move.SetDirection(-parts.move.direction);
        }
    }

    private IEnumerator ExitTransition()
    {
        var parts = ghost.GetComponent<GhostParts>();

        parts.move.SetDirection(Vector2.up, true);
        parts.move.rb.isKinematic = true;
        parts.move.enabled = false;

        Vector3 position = transform.position;
        float duration = 0.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            ghost.SetPosition(Vector3.Lerp(position, inside.position, elapsed / duration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0f;

        while (elapsed < duration)
        {
            ghost.SetPosition(Vector3.Lerp(inside.position, outside.position, elapsed / duration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        parts.move.SetDirection(new Vector2(Random.value < 0.5f ? -1f : 1f, 0f), true);
        parts.move.rb.isKinematic = false;
        parts.move.enabled = true;
    }
}
