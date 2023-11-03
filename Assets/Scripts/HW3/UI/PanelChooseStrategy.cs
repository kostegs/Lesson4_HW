using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Lesson4.HW3
{
    public class PanelChooseStrategy : MonoBehaviour
    {
        [SerializeField] private Button _popAllBalls;
        [SerializeField] private Button _popOneColorBalls;

        private ISceneLoadMediator _sceneLoadMediator;

        [Inject]
        private void Construct(ISceneLoadMediator sceneLoadMediator)
        {
            _sceneLoadMediator = sceneLoadMediator;
        }
            

        private void OnEnable()
        {
            _popAllBalls.onClick.AddListener(OnPopAllBallsStrategyChoosen);
            _popOneColorBalls.onClick.AddListener(OnPopOneColorBallsStrategyChoosen);
        }

        private void OnDisable()
        {
            _popAllBalls.onClick.RemoveListener(OnPopAllBallsStrategyChoosen);
            _popOneColorBalls.onClick.RemoveListener(OnPopOneColorBallsStrategyChoosen);
        }

        private void OnPopAllBallsStrategyChoosen()
            => _sceneLoadMediator.GoToGamePlay(new LevelLoadingData(WinningStrategy.DestroyAllColors));        

        private void OnPopOneColorBallsStrategyChoosen()
            => _sceneLoadMediator.GoToGamePlay(new LevelLoadingData(WinningStrategy.DestroyAllElementsOfOneColor));
        
    }
}
