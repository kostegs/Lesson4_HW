using System;
using UnityEngine;

namespace Lesson4.HW3
{
    public class Ball : MonoBehaviour
    {
        public BallColors Colour => _colour;
        public event Action<Ball> IsPoped;

        private BallColors _colour;

        public void Initialize(BallColors colour)
            => _colour = colour;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Player>(out _))
            {
                IsPoped?.Invoke(this);  
                Destroy(gameObject);                
            }
        }
        
    }
}
