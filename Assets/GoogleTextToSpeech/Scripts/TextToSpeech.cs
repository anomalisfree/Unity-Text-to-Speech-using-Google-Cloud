using System;
using GoogleTextToSpeech.Scripts.Data;
using UnityEngine;
using Input = GoogleTextToSpeech.Scripts.Data.Input;

namespace GoogleTextToSpeech.Scripts
{
    public class TextToSpeech : MonoBehaviour
    {
        [SerializeField] private string apiKey;

        private Action<string> _actionRequestReceived;
        private Action<BadRequestData> _errorReceived;
        private Action<AudioClip> _audioClipReceived;

        private RequestService _requestService;
        private static AudioConverter _audioConverter;

        public void GetSpeechAudioFromGoogle(string textToConvert, VoiceScriptableObject voice, Action<AudioClip> audioClipReceived,  Action<BadRequestData> errorReceived)
        {
            _actionRequestReceived += (requestData => RequestReceived(requestData,audioClipReceived));

            if (_requestService == null)
                _requestService = gameObject.AddComponent<RequestService>();

            if (_audioConverter == null)
                _audioConverter = gameObject.AddComponent<AudioConverter>();

            var dataToSend = new DataToSend
            {
                input =
                    new Input()
                    {
                        text = textToConvert
                    },
                voice =
                    new Voice()
                    {
                        languageCode = voice.languageCode,
                        name = voice.name
                    },
                audioConfig =
                    new AudioConfig()
                    {
                        audioEncoding = "MP3",
                        pitch = voice.pitch,
                        speakingRate = voice.speed
                    }
            };

            RequestService.SendDataToGoogle("https://texttospeech.googleapis.com/v1/text:synthesize", dataToSend,
                apiKey, _actionRequestReceived, errorReceived);
        }

        private static void RequestReceived(string requestData, Action<AudioClip> audioClipReceived)
        {
            var audioData = JsonUtility.FromJson<AudioData>(requestData);
            AudioConverter.SaveTextToMp3(audioData);
            _audioConverter.LoadClipFromMp3(audioClipReceived);
        }
    }
}