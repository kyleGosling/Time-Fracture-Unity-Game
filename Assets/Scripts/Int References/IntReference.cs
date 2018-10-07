using UnityEngine;

// Credit for using ScriptableObjects in this manner...
// https://github.com/roboryantron/Unite2017
//
// Demo'ed in his Unity talk...
// https://www.youtube.com/watch?v=raQ3iHhE_Kk

[CreateAssetMenu(fileName = "New Int Reference", menuName = "Scriptable Objects/Int Reference")]
public class IntReference : ScriptableObject
{ 
    public int Value;

    [SerializeField]
    private int DefaultValue;

    public void OnEnable()
    {
        this.Value = this.DefaultValue;
    }
}
