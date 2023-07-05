using System.IO;
using System.Media;

namespace FMS
{
    class ClickSound
    {
        string MusicPath =  Directory.GetCurrentDirectory()+ @"\click.wav";
        string EatPath = Directory.GetCurrentDirectory() + @"\Feed.wav"; 
        string GameOverPath = Directory.GetCurrentDirectory() + @"\gameOver.wav";
        SoundPlayer player = new SoundPlayer();

        public void RunClickSound()
        {
            player.SoundLocation = MusicPath;
            player.Play();
        }
        public void RunEatSound()
        {
            player.SoundLocation = EatPath;
            player.Play();
        }

        public void RunGameOver()
        {
            player.SoundLocation = GameOverPath;
            player.Play();
        }

    }
}
