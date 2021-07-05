using System;

using UnityEngine;

using JetBrains.Annotations;

namespace CookingPrototype.Kitchen {
	[RequireComponent(typeof(FoodPlace))]
	public sealed class FoodTrasher : MonoBehaviour {

		FoodPlace _place = null;
		float     _timer = 0f;
		
		private const float DOUBLE_CLICK_TIME = 0.25f;

		void Start() {
			_place = GetComponent<FoodPlace>();
			_timer = Time.realtimeSinceStartup;
		}

		/// <summary>
		/// Освобождает место по двойному тапу если еда на этом месте сгоревшая.
		/// </summary>
		[UsedImplicitly]
		public void TryTrashFood() {
			if (Time.realtimeSinceStartup - _timer > DOUBLE_CLICK_TIME) 
			{
				_timer = Time.realtimeSinceStartup;
				return;
			}
			if (_place != null && _place.CurFood.CurStatus == Food.FoodStatus.Overcooked)
				_place.FreePlace();
		}
	}
}
