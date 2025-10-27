using Assets.Code.Gameplay.Input;
using Assets.Code.Gameplay.SoundEffect;
using Assets.Code.Gameplay.SoundEffect.Config;
using Assets.Code.Meta.UI.Windows;
using Assets.Code.Meta.UI.Windows.Config;
using Cysharp.Threading.Tasks;

namespace Assets.Code.Infrastructure.StaticData
{
	public interface IStaticDataService
	{
		UniTask LoadAll();
		WindowConfig GetWindowConfig(WindowId id);
    SoundEffectConfig GetSoundEffectConfig(SoundEffectTypeId typeId);
    HeadConfig GetHeadConfig();
    SmasherConfig GetSmasherConfig();
	}
}