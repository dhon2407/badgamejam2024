using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Main.DialogueSystem
{
    [HideMonoScript]
    [CreateAssetMenu(fileName = "VO_", menuName = "DialogueSystem/Voiceover table", order = 0)]
    public class VoiceOverTable : ScriptableObject
    {
        [Title("Voice Over Table")]
        [SerializeField, TableList] private LineIDMap[] voiceOverTable;
        
        [Serializable]
        private struct LineIDMap
        {
            public string lineID;
            public Object voiceObject;
        }

        /// <summary>
        /// Get line ID voice over object
        /// </summary>
        /// <param name="lineID">Line ID (e.g.:03a8470)</param>
        /// <returns>Voice over object. Returns null if no line ID found</returns>
        public Object GetVoiceObject(string lineID)
        {
            foreach (LineIDMap voData in voiceOverTable)
            {
                if (lineID.Equals($"line:{voData.lineID}"))
                    return voData.voiceObject;
            }

            return null;
        }
    }
}