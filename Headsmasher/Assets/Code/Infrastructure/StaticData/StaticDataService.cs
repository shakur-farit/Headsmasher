using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Gameplay.Input;
using Assets.Code.Gameplay.SoundEffect;
using Assets.Code.Gameplay.SoundEffect.Config;
using Assets.Code.Infrastructure.AssetsProvider;
using Assets.Code.Meta.UI.Windows;
using Assets.Code.Meta.UI.Windows.Config;
using Cysharp.Threading.Tasks;

namespace Assets.Code.Infrastructure.StaticData
{
	public class StaticDataService : IStaticDataService
	{
		private const string HeadConfigAddress = "HeadConfig";
		private const string SmasherConfigAddress = "SmasherConfig";
		private const string WindowConfigLabel = "WindowConfig";
		private const string SoundEffectConfigLabel = "SoundEffectConfig";

		private Dictionary<WindowId, WindowConfig> _windowById;
		private Dictionary<SoundEffectTypeId, SoundEffectConfig> _soundEffectById;
		private HeadConfig _head;
		private SmasherConfig _smasher;

		private readonly IAssetProvider _assetProvider;

		public StaticDataService(IAssetProvider assetProvider) => 
			_assetProvider = assetProvider;

		public async UniTask LoadAll()
		{
			await LoadWindows();
      await LoadSoundEffects();
      await LoadHead();
      await LoadSmasher();
    }

		public WindowConfig GetWindowConfig(WindowId id)
		{
			if (_windowById.TryGetValue(id, out WindowConfig config))
				return config;

			throw new Exception($"Window config for {id} was not found");
		}


    public SoundEffectConfig GetSoundEffectConfig(SoundEffectTypeId typeId)
    {
      if (_soundEffectById.TryGetValue(typeId, out SoundEffectConfig config))
        return config;

      throw new Exception($"Sound effect config for {typeId} was not found");
    }

    public HeadConfig GetHeadConfig() => 
	    _head;

    public SmasherConfig GetSmasherConfig() =>
	    _smasher;

		private async UniTask LoadWindows() =>
			_windowById = (await _assetProvider.LoadAll<WindowConfig>(WindowConfigLabel))
				.ToDictionary(x => x.TypeId, x => x);

    private async UniTask LoadSoundEffects() =>
      _soundEffectById = (await _assetProvider.LoadAll<SoundEffectConfig>(SoundEffectConfigLabel))
        .ToDictionary(x => x.TypeId, x => x);

    private async UniTask LoadHead() =>
	    _head = (await _assetProvider.Load<HeadConfig>(HeadConfigAddress));

    private async UniTask LoadSmasher() =>
	    _smasher = (await _assetProvider.Load<SmasherConfig>(SmasherConfigAddress));
	}
}