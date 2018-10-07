using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class DisplayFloatReference : MonoBehaviour
{
    public FloatReference FloatReference;

    private Text Text;

    private void Awake()
    {
	this.Text = this.GetComponent<Text>();
    }

    private void Update()
    {
	this.Text.text = Mathf.FloorToInt(this.FloatReference.Value).ToString();
    }
}
