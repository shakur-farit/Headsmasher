using System;
using Assets.Code.Infrastructure.StaticData;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Input
{
	public class SmasherFactory : ISmasherFactory
	{
		private readonly IInstantiator _instantiator;
		private readonly IStaticDataService _staticDataService;

		public SmasherFactory(IInstantiator instantiator, IStaticDataService staticDataService)
		{
			_instantiator = instantiator;
			_staticDataService = staticDataService;
		}

		public GameObject CreateSmasher()
		{
			SmasherConfig config = _staticDataService.GetSmasherConfig();

			return _instantiator.InstantiatePrefab(
				config.Prefab, config.StartPosition, Quaternion.identity, null);
		}
	}
}