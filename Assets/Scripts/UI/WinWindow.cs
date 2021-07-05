using UnityEngine;
using UnityEngine.UI;

using CookingPrototype.Controllers;

using TMPro;

namespace CookingPrototype.UI {
	public sealed class WinWindow : Window{
		public Image    GoalBar     = null;
		public TMP_Text GoalText    = null;
		public Button   OkButton    = null;
		public Button   CloseButton = null;

		protected override void Init() {
			var gc = GameplayController.Instance;

			OkButton   .onClick.AddListener(gc.CloseGame);
			CloseButton.onClick.AddListener(gc.CloseGame);
		}

		public override void Show () {
			base.Show();
			
			var gc = GameplayController.Instance;

			GoalText.text      = $"{gc.TotalOrdersServed}/{gc.OrdersTarget}";
			GoalBar.fillAmount = Mathf.Clamp01((float) gc.TotalOrdersServed / gc.OrdersTarget);
		}
	}
}
