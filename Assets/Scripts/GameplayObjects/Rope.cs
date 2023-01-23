using UnityEngine;

namespace Assets.Scripts.GameplayObjects
{
    public class Rope : MonoBehaviour, IRope
    {
        private Transform _pinataAnchorPoint;

        public void Init(Transform anchorPoint)
        {
            _pinataAnchorPoint = anchorPoint;
            transform.position = _pinataAnchorPoint.position;
        }

        private void Update()
        {
            transform.position = _pinataAnchorPoint.position;
        }
    }
}

