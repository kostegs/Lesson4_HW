using UnityEngine;

namespace Lesson4.HW3
{
    public class UIWinningPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _winningPanel;

        public void OnWin() => _winningPanel.SetActive(true);
    }
}
