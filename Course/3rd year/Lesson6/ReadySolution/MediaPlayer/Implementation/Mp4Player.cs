using MediaPlayer.Interfaces;

namespace MediaPlayer.Implementation;

public class Mp4Player : IVideoPlayer
{
    public void PlayVideo(string filename)
    {
        Console.WriteLine($"Воспроизведение {filename}");
    }
}