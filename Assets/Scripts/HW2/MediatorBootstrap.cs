using UnityEngine;

public class MediatorBootstrap : MonoBehaviour
{
    [SerializeField] private GameplayMediator _mediator;
    [SerializeField] private DefeatPanel _defeatPanel;

    private Level _level;

    private void Awake()
    {
        _level = new Level();

        _mediator.Initialize(_level);
        _defeatPanel.Initialize(_mediator);

        _level.Start();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            _level.OnDefeat();
    }
}
