using System;

namespace GoogleTextToSpeech.Scripts.Data
{
    [Serializable]
    public class DataToSend
    {
        public Input input;
        public Voice voice;
        public AudioConfig audioConfig;
    }

    [Serializable]
    public class Input
    {
        public string text;
    }

    [Serializable]
    public class Voice
    {
        public string languageCode;
        public string name;
    }

    [Serializable]
    public class AudioConfig
    {
        public string audioEncoding;
        public float pitch;
        public float speakingRate;
    }
}