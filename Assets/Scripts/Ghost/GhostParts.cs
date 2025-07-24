using UnityEngine;

public class GhostParts : MonoBehaviour
{
    public Movement move { get; private set; }
    public GhostSpawn spawn { get; private set; }
    public GhostScatter scatter { get; private set; }
    public GhostFollow follow { get; private set; }
    public GhostPPE ghostppe { get; private set; }

    private void Awake()
    {
        move = GetComponent<Movement>();
        spawn = GetComponent<GhostSpawn>();
        scatter = GetComponent<GhostScatter>();
        follow = GetComponent<GhostFollow>();
        ghostppe = GetComponent<GhostPPE>();
    }
}
