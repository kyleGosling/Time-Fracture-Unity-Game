using UnityEngine;

// Credit for using ScriptableObjects in this manner...
// https://github.com/roboryantron/Unite2017
//
// Demo'ed in his Unity talk...
// https://www.youtube.com/watch?v=raQ3iHhE_Kk

[CreateAssetMenu(fileName = "New Float Reference", menuName = "Scriptable Objects/Float Reference")]
public class FloatReference : ScriptableObject
{
    public float Value;

    [SerializeField]
    private float DefaultValue;

    public void OnEnable()
    {
        this.Value = this.DefaultValue;
    }
}
