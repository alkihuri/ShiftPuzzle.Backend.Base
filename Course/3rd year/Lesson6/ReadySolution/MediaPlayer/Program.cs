//Задача: Разработать приложение для мультимедийного плеера, поддерживающее воспроизведение различных форматов файлов.
//Идеи: Создать интерфейсы для воспроизведения аудио и видео, а также реализовать их для различных форматов (MP3, WAV, MP4).

using MediaPlayer.Implementation;
using MediaPlayer.Interfaces;

IAudioPlayer audioPlayer = new Mp3Player();
IVideoPlayer videoPlayer = new Mp4Player();

var player = new MultimediaPlayer(audioPlayer, videoPlayer);

player.Play("song.mp3");
player.Play("movie.mp4");
player.Play("sound.wav");
player.Play("text.txt");