using Assets.Code.Infrastructure.StaticData;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Input
{
	public class HeadFactory : IHeadFactory
	{
		private readonly IInstantiator _instantiator;
		private readonly IStaticDataService _staticDataService;

		public HeadFactory(IInstantiator instantiator, IStaticDataService staticDataService)
		{
			_instantiator = instantiator;
			_staticDataService = staticDataService;
		}

		public GameObject CreateHead()
		{
			HeadConfig config = _staticDataService.GetHeadConfig();

			return _instantiator.InstantiatePrefab(
				config.Prefab, config.StartPosition, Quaternion.identity, null);
		}
	}
}