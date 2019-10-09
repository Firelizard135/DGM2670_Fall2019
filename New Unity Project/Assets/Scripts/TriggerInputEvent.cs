using UnityEngine;
using UnityEngine.Events;

public class TriggerInputEvent : MonoBehaviour
{
    // *Not Finished/Working

	public UnityEvent ButtonDownEvent, ButtonUpEvent;
	
	private void GetButtonDown(Collider other)
	{
		ButtonDownEvent.Invoke();
	}

	private void OnTriggerExit(Collider other)
	{
		ButtonUpEvent.Invoke();
	}
}