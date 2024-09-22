using MediaPlayer.Interfaces;

namespace MediaPlayer.Implementation;

public class Mp3Player : IAudioPlayer
{
    public void PlayAudio(string filename)
    {
        Console.WriteLine($"Воспроизведение {filename}");
    }
}