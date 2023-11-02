using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Lesson4.HW3
{
    public class UICountOfColors : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _countOfColorsText;

        public void OnCountChanged(object sender, SphereEventArgs eventArgs)
        {
            var countOfColors = eventArgs.CountOfColors as Dictionary<BallColors, int>;
            string text = "���������� ����� �� ������: ";
            
            foreach (var KeyValue in countOfColors)
            {
                text += $"{KeyValue.Key}: {KeyValue.Value} | ";
            }

            _countOfColorsText.text = text; 
        }
    }
}
