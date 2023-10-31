using UnityEngine;

namespace Task4
{
    public class UIWinningPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _winningPanel;

        public void OnWin() => _winningPanel.SetActive(true);
    }
}
