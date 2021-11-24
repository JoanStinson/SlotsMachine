namespace JGM.Game.Audio
{
    public interface IAudioService
    {
        void Play(in string audioFileName, bool loop = false);
        void Stop(in string audioFileName);
        bool IsPlaying(in string audioFileName);
        void SetVolume(in string audioFileName, in float volume);
    }
}