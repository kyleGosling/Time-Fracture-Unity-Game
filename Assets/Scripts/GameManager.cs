using System.Collections;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get; private set;
    }
    public bool IsPaused
    {
        get; private set;
    } 
    public delegate void TogglePause(bool status);

    private TogglePause PauseEvent;

    private void Awake()
    {
        if (GameManager.Instance == null)
            GameManager.Instance = this;
        else
            Destroy(this);

        this.IsPaused = false;
    }

    public void PauseUnpause()
    {
        this.IsPaused = !this.IsPaused;

        if (this.PauseEvent != null)
            this.PauseEvent(this.IsPaused);
    }

    public void SubscribeToPause(TogglePause subscriber)
    {
        this.PauseEvent += subscriber;
    }
}