using System;
using System.Collections.Generic;

public class PauseHandler : IPause, IDisposable
{
    public PauseHandler(InputHandler inputHandler)
    {
        _inputHandler = inputHandler;
        _inputHandler.KeyPauseOnPressed += OnPauseEnabled;
        _inputHandler.KeyPauseOffPressed += OnPauseDisabled;
    }

    private InputHandler _inputHandler;
    private List<IPause> _handlers = new List<IPause>();

    public void OnPauseEnabled() => SetPause(true);

    public void OnPauseDisabled() => SetPause(false);

    public void Add(IPause handler) => _handlers.Add(handler);

    public void Remove(IPause handler) => _handlers.Remove(handler);

    public void SetPause(bool isPaused)
    {
        foreach (var handler in _handlers)
            handler.SetPause(isPaused);
    }
   
    public void Dispose()
    {
        _inputHandler.KeyPauseOnPressed -= OnPauseEnabled;
        _inputHandler.KeyPauseOffPressed -= OnPauseDisabled;
    }
}
