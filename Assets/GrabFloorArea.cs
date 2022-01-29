using UnityEngine;

public class GrabFloorArea : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D col)
	{
		var grab = col.GetComponent<GrabHandler>();
		if (grab == null)
		{
			return;
		}

		grab.SetOnGrabFloorArea(transform);
	}
}
