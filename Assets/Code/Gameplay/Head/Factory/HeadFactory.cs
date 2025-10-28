using System;
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

		public HeadItem CreateHead()
		{
			HeadConfig config = _staticDataService.GetHeadConfig();

			HeadItem head = _instantiator.InstantiatePrefabForComponent<HeadItem>(
				config.Prefab, config.StartPosition, Quaternion.identity, null);

			head.Setup(config.CurrentHp, config.MaxHp, config.PunchScore, config.TakenDamage);

			return head;
		}
	}
}