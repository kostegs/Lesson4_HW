using System;
using UnityEngine;

namespace Lesson4.HW3
{
    public class UiButtonChooseStrategy : MonoBehaviour
    {
        [SerializeField] private EnumWinningStrategy _strategy;

        public static event EventHandler<StrategyEventArgs> StrategyChoosen;

        public void OnClick() => StrategyChoosen?.Invoke(this, new StrategyEventArgs(_strategy));
    }
}
