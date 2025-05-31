using Code.Infrastructure.StaticData;
using Zenject;

namespace Code.Audio.SoundEffects.Factory
{
	public class SoundEffectFactory : ISoundEffectFactory
	{
		private readonly IStaticDataService _staticDataService;
		private readonly IInstantiator _instantiator;

		public SoundEffectFactory(IStaticDataService staticDataService, IInstantiator instantiator)
		{
			_staticDataService = staticDataService;
			_instantiator = instantiator;
		}

		public SoundSfx CreateSoundEffect(SoundEffectTypeId id)
		{
			var config = _staticDataService.GetSoundEffectConfig(id);

			var sfx = _instantiator.InstantiatePrefabForComponent<SoundSfx>(config.ViewPrefab);
			sfx.Setup(config.AudioClip);
			return sfx;
		}
	}
}