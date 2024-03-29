﻿using Assets.Scripts.ScriptableObjects;

namespace Assets.Scripts.GameplayObjects.GameplayObjSubclasses
{
    public class PinataHitPoints : IPinataHitPoints
    {
        //Each "hit point" = 1 short click on the pinata
        private int _hitPoints;
        private readonly GameParameters _gameParams;

        public PinataHitPoints(GameParameters gameParameters)
        {
            _gameParams = gameParameters;
            _hitPoints = _gameParams.PinataClicksToDestroy;
        }

        public bool PinataClick(float clickDuration, out int power)
        {
            power = ClickPower(clickDuration);
            _hitPoints -= power;
            if (_hitPoints <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private int ClickPower(float clickDuration)
        {
            return clickDuration >= _gameParams.LongClickThreshold ? _gameParams.LongClickPower : _gameParams.ShortClickPower;
        }
    }
}
