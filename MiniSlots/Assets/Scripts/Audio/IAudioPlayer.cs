namespace JGM.Game.Audio
{
    public interface IAudioPlayer
    {
        void PlayLooped(in string audioFilename);
        void PlayOneShot(in string audioFilename);
        void Stop();
        bool IsPlaying();
    }

    public interface IMusicAudioPlayer : IAudioPlayer
    {

    }

    public interface ISfxAudioPlayer : IAudioPlayer
    {

    }
}