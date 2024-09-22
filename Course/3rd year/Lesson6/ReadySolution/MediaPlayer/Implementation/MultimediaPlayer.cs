using MediaPlayer.Interfaces;

namespace MediaPlayer.Implementation;

public class MultimediaPlayer
{
    private readonly IAudioPlayer _audioPlayer;
    private readonly IVideoPlayer _videoPlayer;

    public MultimediaPlayer(IAudioPlayer audioPlayer, IVideoPlayer videoPlayer)
    {
        _audioPlayer = audioPlayer;
        _videoPlayer = videoPlayer;
    }

    public void Play(string filename)
    {
        var extension = Path.GetExtension(filename).ToLower();
        switch (extension)
        {
            case ".mp3":
                _audioPlayer.PlayAudio(filename);
                break;
            case ".wav":
                _audioPlayer.PlayAudio(filename);
                break;
            case ".mp4":
                _videoPlayer.PlayVideo(filename);
                break;
            default:
                Console.WriteLine("Неподдерживаемый формат файла");
                break;
        }
    }
}

