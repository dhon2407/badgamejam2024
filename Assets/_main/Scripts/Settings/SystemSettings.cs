using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Audio;

namespace Game.Main.Settings
{
    [HideMonoScript]
    [CreateAssetMenu(fileName = "SystemSettings", menuName = "Settings/System", order = 0)]
    public class SystemSettings : CoreSetting
    {
        protected override string Identifier => nameof(SystemSettings);
        
        [Title("Display Settings")]
        [SerializeField, LabelText("Supported Resolutions (Width x Height)"),
         ListDrawerSettings(NumberOfItemsPerPage = 20)] private Res[] supportedResolutions;
        
        [Title("Sound Settings")] [SerializeField]
        private AudioMixer audioMixer;

        public bool IsResolutionSupported(int width, int height)
        {
            foreach (Res resolution in supportedResolutions)
            {
                if (resolution.width != width || resolution.height != height)
                    continue;

                return true;
            }
            
            return false;
        }
        
        [Serializable]
        private struct Res
        {
            [HorizontalGroup(Width = 0.50f), HideLabel]
            public int width;
            [HorizontalGroup(Width = 0.50f), HideLabel]
            public int height;
        }
    }
}