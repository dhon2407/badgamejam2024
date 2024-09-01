using System.Threading.Tasks;
using UnityEngine;

namespace Game.Main.Settings
{
    public abstract class CoreSetting : ScriptableObject
    {
        protected abstract string Identifier { get; }
        
#if UNITY_EDITOR
        private void Awake()
        {
            string[] guid = UnityEditor.AssetDatabase.FindAssets($"t:{Identifier}");
            if (guid.Length <= 1) return;
            
            Debug.LogError("Already have a setting instance.");
            Object devSettings = UnityEditor.AssetDatabase.LoadMainAssetAtPath(UnityEditor.AssetDatabase.GUIDToAssetPath(guid[0]));
            UnityEditor.Selection.activeObject = devSettings;
            DelayDestroy();
        }
        
        private async void DelayDestroy()
        {
            await Task.Delay(1);
            DestroyImmediate(this);
        }
#endif
    }
}