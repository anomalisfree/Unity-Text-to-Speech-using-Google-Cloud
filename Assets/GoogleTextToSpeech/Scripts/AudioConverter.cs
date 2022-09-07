using System;
using System.Collections;
using System.IO;
using GoogleTextToSpeech.Scripts.Data;
using UnityEngine;
using UnityEngine.Networking;

namespace GoogleTextToSpeech.Scripts
{
    public class AudioConverter : MonoBehaviour
    {
        private const string Mp3FileName = "audio.mp3";

        public static void SaveTextToMp3(AudioData audioData)
        {
            var bytes = Convert.FromBase64String(audioData.audioContent);
            File.WriteAllBytes(Application.temporaryCachePath + "/" + Mp3FileName, bytes);
        }

        public void LoadClipFromMp3(Action<AudioClip> onClipLoaded)
        {
            StartCoroutine(LoadClipFromMp3Cor(onClipLoaded));
        }

        private static IEnumerator LoadClipFromMp3Cor(Action<AudioClip> onClipLoaded)
        {
            var downloadHandler =
                new DownloadHandlerAudioClip("file://" + Application.temporaryCachePath + "/" + Mp3FileName,
                    AudioType.MPEG);
            downloadHandler.compressed = false;

            using var webRequest = new UnityWebRequest("file://" + Application.temporaryCachePath + "/" + Mp3FileName,
                "GET",
                downloadHandler, null);

            yield return webRequest.SendWebRequest();

            if (webRequest.responseCode == 200)
            {
                onClipLoaded.Invoke(downloadHandler.audioClip);
            }
            
            downloadHandler.Dispose();
        }
    }
}