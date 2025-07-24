using UnityEngine;

[DefaultExecutionOrder(-10)]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(GhostParts))]
[RequireComponent(typeof(GhostState))]
[RequireComponent(typeof(GhostHit))]
public class Ghost : MonoBehaviour
{
    public GhostBaseState initialBehavior;
    public Transform target;
    public int points = 200;

    private GhostState ghostState;

    private void Awake()
    {
        ghostState = GetComponent<GhostState>();
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        gameObject.SetActive(true);
        ghostState.Reset(initialBehavior);
    }

    public void SetPosition(Vector3 position)
    {
        position.z = transform.position.z;
        transform.position = position;
    }
}
