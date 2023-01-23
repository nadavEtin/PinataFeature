﻿using Assets.Scripts.Managers;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.GameplayObjects
{
    public interface IPrizeShelfContainer
    {
        ShelfPrizeData ReceivePrize(ObjectTypes prizeType, int amount, GameObject particleFx);

        void Init(AssetReference assetReference, IAnimationManager animationManager);
    }
}
