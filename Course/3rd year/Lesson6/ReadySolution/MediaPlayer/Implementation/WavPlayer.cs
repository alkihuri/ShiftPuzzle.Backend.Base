using MediaPlayer.Interfaces;

namespace MediaPlayer.Implementation;

public class WavPlayer : IAudioPlayer
{
    public void PlayAudio(string filename)
    {
        Console.WriteLine($"Воспроизведение {filename}");
    }
}