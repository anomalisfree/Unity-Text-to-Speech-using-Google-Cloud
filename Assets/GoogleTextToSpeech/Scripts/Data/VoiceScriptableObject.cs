using UnityEngine;

namespace GoogleTextToSpeech.Scripts.Data
{
    [CreateAssetMenu(fileName = "Voice", menuName = "GoogleTextToSpeech/Voice", order = 1)]
    public class VoiceScriptableObject : ScriptableObject
    {
        public string languageCode;
        public new string name;
        [Range(0.25f, 4f)]
        public float speed = 1;
        [Range(-20f, 20f)]
        public float pitch;
    }
}
