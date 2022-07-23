using System;
using LiteNinja.Systems;
using UnityEngine;

namespace Maestro.Systems
{
    [AddComponentMenu("Maestro/Systems/Garbage Collector")]
    public class GarbageCollectorSystem : ATickableSystem
    {
        protected override void OnLoadSystem()
        {
        }

        protected override void OnUnloadSystem()
        {
            
        }

        protected override void OnTick(float deltaTime)
        {
            GC.Collect();
        }
    }
}