using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Lesson4.HW3
{
    public class CountOfColors : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _countOfColorsText;

        private IBallStorageMediator _ballStorageMediator;

        [Inject]
        private void Construct(IBallStorageMediator ballStorageMediator)
            => _ballStorageMediator = ballStorageMediator;        

        private void OnEnable() 
        {
            _ballStorageMediator.BallPoped += OnBallPoped;            
            ShowTextCountOfBalls();
        }

        private void OnDisable() 
            => _ballStorageMediator.BallPoped -= OnBallPoped; 

        public void OnBallPoped(Ball ball) => ShowTextCountOfBalls();

        private void OnBallAddedToStorage() => ShowTextCountOfBalls();
        
        private void ShowTextCountOfBalls()
        {
            string text = "Количество шаров по цветам: ";

            var ballColors = Enum.GetValues(typeof(BallColors));

            foreach (var colour in ballColors)
            {
                switch (colour)
                {
                    case BallColors.Red:
                        text += $"Красный: {_ballStorageMediator.GetCount(BallColors.Red)} | ";
                        break;
                    case BallColors.Blue:
                        text += $"Синий: {_ballStorageMediator.GetCount(BallColors.Blue)} | ";
                        break;
                    default:
                        throw new ArgumentException(nameof(colour));
                }
            }

            _countOfColorsText.text = text;
        }
    }
}
