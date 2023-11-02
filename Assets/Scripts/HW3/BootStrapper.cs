using System.Collections.Generic;
using UnityEngine;

namespace Lesson4.HW3
{
    public class BootStrapper : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private List<Sphere> _ballsList;

        [Header("UI")]
        [SerializeField] private UICountOfColors _uiCountOfColors;        
        [SerializeField] private GameObject _panelChoosingStrategy;
        [SerializeField] private GameObject _panelWinning;
        [SerializeField] private UIWinningPanel _winningPanel;
        
        private void Awake()
        {
            BallStorage ballStorage = new BallStorage();            
            ballStorage.CountOfColorsChanged += _uiCountOfColors.OnCountChanged;
            ballStorage.CountOfColorsChanged += _player.CheckWinning;
            ballStorage.Initialize(_ballsList);

            UiButtonChooseStrategy.StrategyChoosen += _player.OnStrategyChoosen;
            _player.OnWin += _winningPanel.OnWin;
        }
    }
}
