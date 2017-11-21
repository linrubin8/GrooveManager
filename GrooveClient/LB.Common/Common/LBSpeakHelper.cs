using SpeechLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;

namespace LB.Common
{
    public class LBSpeakHelper
    {
        public static string SpeakString="";
        private static SpeechSynthesizer speak = new SpeechSynthesizer();
        private static Prompt prompt = null;

        //public static void AddSpeak(string strMsg)
        //{
        //    lock (LstSpeak)
        //    {
        //        if (!LstSpeak.Contains(strMsg))
        //        {
        //            LstSpeak.Add(strMsg);
        //        }
        //    }
        //}

        public static void Speak(enSpeakType eSpeakType)
        {
            string strSpeak = "";
            switch (eSpeakType)
            {
                case enSpeakType.FinishWeight:
                    strSpeak = "称重完毕，请离开秤台";
                    break;
                case enSpeakType.ToWeightCenter:
                    strSpeak = "请停到秤台中间";
                    break;
                case enSpeakType.UpToWeight:
                    strSpeak = "请上秤";
                    break;
                case enSpeakType.UpDownWeight:
                    strSpeak = "请下秤";
                    break;
                case enSpeakType.PleaseCard:
                    strSpeak = "请刷卡";
                    break;
            }

            if (strSpeak != "")
            {
                try
                {
                    SpeakString = strSpeak;
                    //speak.Rate = -3;
                    //speak.SpeakAsync(strSpeak);
                }
                catch (Exception ex)
                {

                }
                //speak.Speak(strSpeak);
                //speak.Dispose();  //释放之前的资源
            }
        }
        
        public static void Speak(string strSpeak)
        {
             if (strSpeak != "")
            {
                try
                {
                    if (prompt==null || prompt.IsCompleted)
                    {
                        speak.Rate = -3;
                        speak.Volume = 100;
                        //speak.SelectVoice("Microsoft Lili");
                        //speak.SelectVoiceByHints(VoiceGender.Neutral, VoiceAge.Adult, 2, System.Globalization.CultureInfo.CurrentCulture);
                        prompt = speak.SpeakAsync(strSpeak);
                    }
                    //speak.Dispose();  //释放之前的资源
                }
                catch (Exception ex)
                {

                }
            }
        }
    }

    public enum enSpeakType
    {
        /// <summary>
        /// 称重完毕，请离开秤台
        /// </summary>
        FinishWeight,

        /// <summary>
        /// 请停到秤台中间
        /// </summary>
        ToWeightCenter,

        /// <summary>
        /// 请上秤
        /// </summary>
        UpToWeight,

        /// <summary>
        /// 请下秤
        /// </summary>
        UpDownWeight,

        /// <summary>
        /// 请刷卡
        /// </summary>
        PleaseCard
    }
}
