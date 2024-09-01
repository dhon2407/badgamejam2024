using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Main.Settings
{
    [HideMonoScript]
    [CreateAssetMenu(fileName = "SettingsController", menuName = "Settings/Controller", order = 0)]
    public class GameSettings : ScriptableObject
    {
        public static bool Ready => _instance != null;

        public static DialogueSettings Dialog => Instance.dialogueSettings;
        public static SystemSettings System => Instance.systemSettings;

        [Title("Dialogue Settings")] [Required, SerializeField, PropertyOrder(int.MaxValue)]
        private DialogueSettings dialogueSettings;

        [Title("System Settings")] [Required, SerializeField, PropertyOrder(int.MaxValue)]
        private SystemSettings systemSettings;

        #region INSTANCE SETUP

        private static GameSettings _instance;
        private static GameSettings Instance => _instance ? _instance : Initialize();

        private static GameSettings Initialize()
        {
            _instance = Resources.Load<GameSettings>("Game/SettingsController");
            return _instance;
        }

        #endregion
    }
}