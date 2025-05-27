namespace Code.Gameplay.Quest
{
	public interface ISoundEffectFactory
	{
		SoundSfx CreateSoundEffect(SoundEffectTypeId id);
	}
}