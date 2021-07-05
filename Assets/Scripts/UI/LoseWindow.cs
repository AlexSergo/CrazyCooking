using UnityEngine;
using UnityEngine.UI;

using  CookingPrototype.Controllers;

using TMPro;

namespace CookingPrototype.UI {
	public sealed class LoseWindow : Window {
		public Image    GoalBar      = null;
		public TMP_Text GoalText     = null;
		public Button   ReplayButton = null;
		public Button   ExitButton   = null;
		public Button   CloseButton  = null;

		protected override void Init() {
			var gc = GameplayController.Instance;

			ReplayButton.onClick.AddListener(gc.Restart);
			ExitButton  .onClick.AddListener(gc.CloseGame);
			CloseButton .onClick.AddListener(gc.CloseGame);
		}

		public override void Show() {
			base.Show();

			var gc = GameplayController.Instance;

			GoalBar.fillAmount = Mathf.Clamp01((float) gc.TotalOrdersServed / gc.OrdersTarget);
			GoalText.text = $"{gc.TotalOrdersServed}/{gc.OrdersTarget}";

		}
	}
}
