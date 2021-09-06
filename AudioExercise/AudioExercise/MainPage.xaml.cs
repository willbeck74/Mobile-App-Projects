using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Plugin.SimpleAudioPlayer;
using Xamarin.Forms;

namespace AudioExercise
{
    public partial class MainPage : ContentPage
    {
       
        ISimpleAudioPlayer player = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
        public MainPage()
        {
            InitializeComponent();
            Load("hello.mp3");
        }
        private void Load(string file)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            String ns = "AudioExercise";
            Stream audioStream = assembly.GetManifestResourceStream(ns + "." + file);
            player.Load(audioStream);
        }
      

        void Play_Clicked(System.Object sender, System.EventArgs e)
        {
            player.Play();
        }

        void Stop_Clicked(System.Object sender, System.EventArgs e)
        {
            player.Stop();
        }

        void loopSwitch_PropertyChanged(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            player.Loop = !player.Loop;
        }
    }
}
