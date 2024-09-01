using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Game.Main.Settings
{
    [HideMonoScript]
    [CreateAssetMenu(fileName = "DialogueSettings", menuName = "Settings/Dialogue", order = 0)]
    public class DialogueSettings : CoreSetting
    {
        protected override string Identifier => nameof(DialogueSettings);

        [Title("Dialogue System Prefab")]
        [SerializeField] private GameObject dialogueSystem;
        
        [Title("Character Frame Icons")]
        [SerializeField] private Sprite unknownCharacterSprite;
        [SerializeField] private CharacterSprite[] heroImageSprite;

        public GameObject Instantiate() => Instantiate(dialogueSystem);

        /// <summary>
        /// Get character default frame sprite
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public Sprite GetDefaultFrameSprite(Character character)
        {
            foreach (CharacterSprite characterSprite in heroImageSprite)
            {
                if (characterSprite.character == character)
                    return characterSprite.defaultSprite;
            }

            Debug.LogWarning($"Character:{character} doesn't have a sprite properly set.");
            return unknownCharacterSprite;
        }
        
        /// <summary>
        /// Get character assigned pose sprite
        /// </summary>
        /// <param name="character">Character name</param>
        /// <param name="poseName">Assigned pose name</param>
        /// <returns></returns>
        public Sprite GetPoseFrameSprite(Character character, string poseName)
        {
            foreach (CharacterSprite characterSprite in heroImageSprite)
            {
                if (characterSprite.character != character)
                    continue;
                
                foreach (Pose pose in characterSprite.poses)
                {
                    if (poseName.Equals(pose.poseName))
                        return pose.spritePose;
                }
                    
                Debug.LogWarning($"Character:{character} pose:{poseName} not found.");
                return characterSprite.defaultSprite;
            }

            Debug.LogWarning($"Character:{character} doesn't have a sprite properly set.");
            return unknownCharacterSprite;
        }
        
        [Serializable]
        private struct CharacterSprite
        { 
            [HideLabel]
            public Character character;
            [PreviewField]
            public Sprite defaultSprite;
            [SerializeField, ListDrawerSettings(NumberOfItemsPerPage = 5)]
            public Pose[] poses;
        }

        [Serializable]
        private struct Pose
        {
            [HorizontalGroup(Width = 0.75f), HideLabel]
            public string poseName;
            [HorizontalGroup(Width = 0.25f), HideLabel, PreviewField]
            public Sprite spritePose;
        }
    }
}