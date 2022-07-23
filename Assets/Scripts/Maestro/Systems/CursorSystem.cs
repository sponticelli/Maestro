using LiteNinja.Systems;
using UnityEngine;

namespace Maestro.Systems
{
    /// <summary>
    /// 
    /// </summary>
    [AddComponentMenu("Maestro/Systems/Interaction System")]
    public class CursorSystem : ASystem
    {
        [Header("Mouse cursor")]
        [SerializeField] private Texture2D _cursorTexture;


        protected override void OnLoadSystem()
        {
            Cursor.SetCursor(_cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
        }

        protected override void OnUnloadSystem()
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}