using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Text))]
public class DisplayIntReference : MonoBehaviour
{    
    public IntReference IntReference;
    private Text Text;

    private void Awake()
    {
	this.Text = this.GetComponent<Text>();
    }

    private void Update()
    {
	this.Text.text = this.IntReference.Value.ToString();
    }
}
