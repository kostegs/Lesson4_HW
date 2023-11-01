using UnityEngine;
using Zenject;

public class InputHandler : ITickable
{
    private PauseHandler _pauseHandler;

    public InputHandler(PauseHandler pauseHandler)
        => _pauseHandler = pauseHandler;

    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.F))
            _pauseHandler.SetPause(true);

        if (Input.GetKeyDown(KeyCode.S))
            _pauseHandler.SetPause(false);
    }
}
