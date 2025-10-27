using System;

namespace Assets.Code.Infrastructure.Loading
{
	public interface ISceneLoader
	{
		void LoadScene(string name, Action onLoaded = null);
	}
}