using UnityEngine;

[CreateAssetMenu]
public class BoolData : ScriptableObject
{
    public bool boolean;
    
    public void ToggleBool() {
        boolean = !boolean;
    }

    public void SetBoolTrue() {
        boolean = true;
    }

    public void SetBoolFalse() {
        boolean = false;
    }

    public void LogMessage(string message) {
        Debug.Log(message);
    }

    // public void CreateParticle(GameObject particle) {
    //     Instantiate(jumpParticle, Quaternion.identity, Quaternion.identity);
    // }
}
