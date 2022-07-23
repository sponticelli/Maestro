using System;
using LiteNinja.Systems;
using UnityEngine;

namespace Maestro.Systems
{
    public class GarbageCollectorSystem : ATickableSystem
    {
        protected override void OnLoadSystem()
        {
        }

        protected override void OnTick(float deltaTime)
        {
            GC.Collect();
        }
    }
}