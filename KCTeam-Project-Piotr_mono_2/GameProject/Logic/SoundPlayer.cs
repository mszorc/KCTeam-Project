using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class SoundPlayer
    {
        public WaveOutEvent waveOut = new WaveOutEvent();
        public WaveFileReader waveFileReader;

        public SoundPlayer(string music)
        {
            waveFileReader = new WaveFileReader(music);
        }
        public  void PlayMusic()
        {
            waveOut.Init(waveFileReader);
            waveOut.Play();
        }
        public  void StopMusic()
        {
            waveOut.Stop();
        }
    }
}
