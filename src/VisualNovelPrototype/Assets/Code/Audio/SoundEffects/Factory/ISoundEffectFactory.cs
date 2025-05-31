namespace Code.Audio.SoundEffects.Factory
{
	public interface ISoundEffectFactory
	{
		SoundSfx CreateSoundEffect(SoundEffectTypeId id);
	}
}