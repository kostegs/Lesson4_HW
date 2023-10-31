using UnityEngine;

namespace Task4
{
    public class Sphere : MonoBehaviour
    {
        [field: SerializeField] public SphereColors Color { get; private set; }

        private BallStorage _ballStorage;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Player>(out _))
            {
                Destroy(gameObject);
                _ballStorage.SubtractColorCount(Color, 1);
            }
        }

        public void SetBallStorage(BallStorage ballStorage) => _ballStorage = ballStorage;
    }
}
