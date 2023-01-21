﻿using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameplayObjects.GameplayObjUtility
{
    internal interface IParticleScript
    {
        void Init(Action<GameObject, ObjectTypes> endCb, ObjectTypes type);
    }
}