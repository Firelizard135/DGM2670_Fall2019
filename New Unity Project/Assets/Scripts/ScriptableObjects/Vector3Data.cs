using UnityEngine;

[CreateAssetMenu]
public class Vector3Data : ScriptableObject
{
    public Vector3 value = new Vector3(1f,1f,1f);

    public void LogMessage(string message) {
        Debug.Log(message);
    }

    // public void CreateParticle(GameObject particle) {
    //     Instantiate(jumpParticle, Quaternion.identity, Quaternion.identity);
    // }
}
