# Unity-Text-to-Speech-using-Google-Cloud

The code is designed to convert text to voice using Google Cloud.

----

### For the code to work, you need to enter the api key in the "TEXT_TO_SPEECH" prefab.
#### An example of usage can be found in `GoogleTextToSpeech\Scenes\Example` scene.

----

#### To convert text to an audio clip, use the method:
`GetSpeechAudioFromGoogle(string textToConvert, VoiceScriptableObject voice, Action<AudioClip> audioClipReceived,  Action<BadRequestData> errorReceived)`
from TextToSpeech class

`string textToConvert - text to convert`

`VoiceScriptableObject voice - voice options`

`Action<AudioClip> audioClipReceived - executed in case of successful conversion`

`Action<BadRequestData> errorReceived - executed in case of an error`

----

You can find ready-made voice options in `GoogleTextToSpeech\Voices`.

Or you can create a new set of voice options using  `Create/GoogleTextToSpeech/Voice`.
