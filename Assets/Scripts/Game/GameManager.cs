using UnityEngine;

[DefaultExecutionOrder(-100)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameEvents events;

    private void Awake()
    {
        if (Instance != null)
            DestroyImmediate(gameObject);
        else
            Instance = this;
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    public void PacmanEaten() => events.OnPacmanEaten();
    public void GhostEaten(Ghost ghost) => events.OnGhostEaten(ghost);
    public void PelletEaten(Pellet pellet) => events.OnPelletEaten(pellet);
    public void PowerPelletEaten(PowerPellet pellet) => events.OnPowerPelletEaten(pellet);
}
