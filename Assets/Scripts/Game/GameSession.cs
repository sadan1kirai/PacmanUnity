using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] private GameUI ui;
    [SerializeField] private Ghost[] ghosts;
    [SerializeField] private Pacman pacman;
    [SerializeField] private Transform pellets;

    public int Score { get; private set; }
    public int Lives { get; private set; }

    private int ghostMultiplier = 1;

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (Lives <= 0 && Input.anyKeyDown)
        {
            NewGame();
        }
    }

    public void NewGame()
    {
        Score = 0;
        Lives = 3;

        ui.UpdateScore(Score);
        ui.UpdateLives(Lives);

        NewRound();
    }

    private void NewRound()
    {
        ui.SetGameOverVisible(false);

        foreach (Transform pellet in pellets)
        {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState()
    {
        foreach (Ghost ghost in ghosts)
        {
            ghost.ResetState();
        }

        pacman.ResetState();
    }

    private void GameOver()
    {
        ui.SetGameOverVisible(true);

        foreach (Ghost ghost in ghosts)
        {
            ghost.gameObject.SetActive(false);
        }

        pacman.gameObject.SetActive(false);
    }

    public void PacmanEaten()
    {
        pacman.DeathSequence();
        Lives--;
        ui.UpdateLives(Lives);

        if (Lives > 0)
        {
            Invoke(nameof(ResetState), 3f);
        }
        else
        {
            GameOver();
        }
    }

    public void GhostEaten(Ghost ghost)
    {
        int points = ghost.points * ghostMultiplier;
        Score += points;
        ui.UpdateScore(Score);
        ghostMultiplier++;
    }

    public void PelletEaten(Pellet pellet)
    {
        pellet.gameObject.SetActive(false);

        Score += pellet.points;
        ui.UpdateScore(Score);

        if (!HasRemainingPellets())
        {
            pacman.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3f);
        }
    }

    public void PowerPelletEaten(PowerPellet pellet)
    {
        foreach (Ghost ghost in ghosts)
        {
            ghost.GetComponent<GhostParts>().ghostppe.Enable(pellet.duration);
        }

        PelletEaten(pellet);

        CancelInvoke(nameof(ResetGhostMultiplier));
        Invoke(nameof(ResetGhostMultiplier), pellet.duration);
    }

    private void ResetGhostMultiplier()
    {
        ghostMultiplier = 1;
    }

    private bool HasRemainingPellets()
    {
        foreach (Transform pellet in pellets)
        {
            if (pellet.gameObject.activeSelf)
            {
                return true;
            }
        }

        return false;
    }
}
