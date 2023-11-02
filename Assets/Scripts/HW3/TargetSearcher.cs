using System;
using UnityEngine;

namespace Lesson4.HW3
{
    public class TargetSearcher : IDisposable
    {
        public event Action<Vector3> TargetDefined;

        private Camera _camera;
        private InputHandler _inputHandler;

        public TargetSearcher(Camera camera, InputHandler inputHandler)
        {
            _camera = camera;
            _inputHandler = inputHandler;
            _inputHandler.MouseLeftButtonPressed += OnMouseLeftButtonPressed;
        }

        public void Dispose()
            => _inputHandler.MouseLeftButtonPressed -= OnMouseLeftButtonPressed;

        private void OnMouseLeftButtonPressed(Vector3 mousePosition)
            => SearchTarget(mousePosition);

        private void SearchTarget(Vector3 mousePosition)
        {
            Ray ray = _camera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                Vector3 target = new Vector3(raycastHit.point.x, 0, raycastHit.point.z);
                TargetDefined?.Invoke(target);
            }
        }    
    }
}
