using System;
using System.Threading;
using System.IO;
using System.Speech.Synthesis;
using System.Net;
using System.Windows.Forms;
using NAudio.Wave;

namespace Hopex.YandexSpeech
{
    /// <summary>
    /// YandexSpeech workflow.
    /// </summary>
    public class Speech
    {
        /// <summary>
        /// YandexSpeech workflow.
        /// </summary>
        public Speech() { }

        /// <summary>
        /// Voice over text by default voice.
        /// </summary>
        /// <param name="text">Playback text.</param>
        /// <param name="rate">Rate of speech.</param>
        public void NewSpeech(string text, int rate = 10)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer()
                {
                    Rate = rate
                };
                speechSynthesizer.SelectVoice(Speakers.Alena.ToString().ToLower());
                speechSynthesizer.SpeakAsync(text);
            }
        }

        /// <summary>
        /// Voice over text.
        /// </summary>
        /// <remarks>
        /// Check out the list of languages and the voices supported for them <seealso href="https://cloud.yandex.ru/en/docs/speechkit/tts/voices">here</seealso>.
        /// </remarks>
        /// <param name="key">Accout access key.</param>
        /// <param name="text">Playback text.</param>
        /// <param name="speaker">Voice used.</param>
        /// <param name="emotion">Voice intonation.</param>
        /// <param name="speed">Speed of speech.</param>
        /// <param name="lang">Language of speech.</param>
        public void NewSpeech(string key, string text, Speakers speaker, Emotions emotion, double speed = 1.0, string lang = "en-US") => Playback(key, text, speaker.ToString().ToLower(), emotion.ToString().ToLower(), speed, lang);
        
        /// <summary>
        /// Voice over text.
        /// </summary>
        /// <remarks>
        /// Check out the list of languages and the voices supported for them <seealso href="https://cloud.yandex.ru/en/docs/speechkit/tts/voices">here</seealso>.
        /// </remarks>
        /// <param name="key">Accout access key.</param>
        /// <param name="text">Playback text.</param>
        /// <param name="speaker">Voice used.</param>
        /// <param name="emotion">Voice intonation.</param>
        /// <param name="speed">Speed of speech.</param>
        /// <param name="lang">Language of speech.</param>
        public void NewSpeech(string key, string text, string speaker, string emotion, double speed = 1.0, string lang = "en-US") => Playback(key, text, speaker, emotion, speed, lang);

        private void Playback(string key, string text, string speaker, string emotion, double speed = 1.0, string lang = "en-US")
        {
            string request = "https://tts.voicetech.yandex.net/generate?" + $@"key={key}&text={text}&speaker={speaker.ToString().ToLower()}&emotion={emotion.ToString().ToLower()}&speed={speed}&format=mp3&lang={lang}";
            
            Thread Thread = new Thread(delegate ()
            {
                try
                {
                    using (Stream memoryStream = new MemoryStream())
                    {
                        using (Stream stream = WebRequest.Create(request).GetResponse().GetResponseStream())
                        {
                            byte[] buffer = new byte[32768];
                            int readBytes;
                            while ((readBytes = stream.Read(buffer, 0, buffer.Length)) > 0)
                                memoryStream.Write(buffer, 0, readBytes);
                        }

                        memoryStream.Position = 0;
                        using (WaveStream blockAlignedStream = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(memoryStream))))
                        {
                            using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                            {
                                waveOut.Init(blockAlignedStream);
                                waveOut.Play();
                                while (waveOut.PlaybackState == PlaybackState.Playing)
                                    Thread.Sleep(100);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source);
                }
            });

            Thread.Start();
        }
    }
}
