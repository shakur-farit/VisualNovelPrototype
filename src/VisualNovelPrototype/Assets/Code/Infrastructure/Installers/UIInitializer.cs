using Code.Infrastructure.AssetsManagement;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
	public class UIInitializer : MonoBehaviour, IInitializable
	{
		public RectTransform UIRoot;

		private IWindowFactory _factory;

		[Inject]
		private void Construct(IWindowFactory factory) =>
			_factory = factory;

		public void Initialize() => 
			_factory.SetUIRoot(UIRoot);
	}
}