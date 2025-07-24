using UnityEngine;

public class GameEvents : MonoBehaviour
{
    [SerializeField] private GameSession session;

    public void OnPacmanEaten()
    {
        session.PacmanEaten();
    }

    public void OnGhostEaten(Ghost ghost)
    {
        session.GhostEaten(ghost);
    }

    public void OnPelletEaten(Pellet pellet)
    {
        session.PelletEaten(pellet);
    }

    public void OnPowerPelletEaten(PowerPellet pellet)
    {
        session.PowerPelletEaten(pellet);
    }
}
