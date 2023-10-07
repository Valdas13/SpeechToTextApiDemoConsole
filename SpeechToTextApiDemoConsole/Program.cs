// Demo for " Google.Cloud.Speech.V1 "
using Google.Cloud.Speech.V1;

var speech = SpeechClient.Create();
RecognitionConfig config;


Console.WriteLine("The task starts...");
Console.Write("Case number (1-brooklin or 2-lithuanian):");
var caseNumber = Console.ReadLine()?.Trim();

switch (caseNumber)
{
    case "1":
        {
            config = new RecognitionConfig
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Flac,
                // Config for "brooklyn.flac"
                SampleRateHertz = 16000,
                LanguageCode = LanguageCodes.English.UnitedStates
            };

            // Using file "brooklyn.flac" in local disk directory "D:\Temp\brooklyn.flac"
            var audio1 = RecognitionAudio.FromFile(@"D:\Temp\brooklyn.flac");
            // English transcription
            var audio2 = RecognitionAudio.FromStorageUri("gs://cloud-samples-tests/speech/brooklyn.flac");

            Console.WriteLine(@"Part1 . Using file D:\Temp\brooklyn.flac");
            var response1 = speech.Recognize(config, audio1);

            foreach (var result in response1.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    Console.WriteLine(alternative.Transcript);
                }
            }

            Console.WriteLine("Part2 . Using gs://cloud-samples-tests/speech/brooklyn.flac");
            var response2 = speech.Recognize(config, audio2);

            foreach (var result in response2.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    Console.WriteLine(alternative.Transcript);
                }
            }
            break;
        }
    case "2":
        {
            config = new RecognitionConfig
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Flac,
                // Config for "VD_statyb_blokeliai.flac"
                LanguageCode = LanguageCodes.Lithuanian.Lithuania,
                SampleRateHertz = 48000,
                AudioChannelCount = 2
            };
            // Using file "VD_statyb_blokeliai.flac" in local disk directory "D:\Temp\VD_statyb_blokeliai.flac"
            var audio1 = RecognitionAudio.FromFile(@"D:\Temp\VD_statyb_blokeliai.flac");
            // English transcription
            var audio2 = RecognitionAudio.FromStorageUri("gs://testo_kibiras/VD_statyb_blokeliai.flac");

            Console.WriteLine(@"Part1 . Using file D:\Temp\VD_statyb_blokeliai.flac");
            var response1 = speech.Recognize(config, audio1);

            foreach (var result in response1.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    Console.WriteLine(alternative.Transcript);
                }
            }

            Console.WriteLine("Part2 . Using gs://cloud-samples-tests/speech/VD_statyb_blokeliai.flac");
            var response2 = speech.Recognize(config, audio2);

            foreach (var result in response2.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    Console.WriteLine(alternative.Transcript);
                }
            }
            break;
        }
    default:
        Console.WriteLine("Wrong case !");
        break;
}

Console.WriteLine("The end...");
