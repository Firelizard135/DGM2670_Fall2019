using UnityEngine;
using UnityEngine.Events;

public class Trigger2D : MonoBehaviour
{
    public UnityEvent TriggerEnterEvent, TriggerExitEvent;
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		TriggerEnterEvent.Invoke();
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		TriggerExitEvent.Invoke();
	}
}
