using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    /// <summary>
    ///   A list of all the environments available to generate
    /// </summary>
    public List<Environment> Environments;

    public int Seed = 0;
    public int FractureDistance = 100;

    public FloatReference PlayerSpeed;

    /// <summary>
    ///   The environment that the player is currently located in
    /// </summary>
    private int CurrentEnvironment = -1;

    /// <summary>
    ///   Represents an index within the BackgroundObjects array, representing the background object that
    ///   is furthest to the left (while still in screen space)
    /// </summary>
    private int CurrentBackgroundIndex = 0;

    [SerializeField]
    private GameObject[] BackgroundObjects;

    [SerializeField]
    private FloatReference DistanceTravelled;

    [SerializeField]
    private GameObject FractureObject;
    

    private void Start()
    {
	    if(this.Seed == 0)
	    {
	        this.Seed = Random.Range(-int.MaxValue, int.MaxValue);
	    }

	    Random.InitState(this.Seed);
	    this.CurrentEnvironment = this.RandomEnvironment();
	    this.UpdateBackgroundSprites();
	    this.PositionFracture();
    }

    private void Update()
    {
        if (!GameManager.Instance.IsPaused)
        {
            this.UpdateBackgroundPositions();
            this.UpdateCurrentBackgroundIndex();
            this.UpdateFracturePosition();
            this.DistanceTravelled.Value += this.PlayerSpeed.Value * Time.deltaTime;
        }
    }

    public void CreateNextEnvironment()
    {
	    this.NextEnvironment();
	    this.UpdateBackgroundSprites();
	    this.PositionFracture();
    }

    /// <summary>
    ///   Moves each background object by the distance travelled by the player in the current frame.
    ///   If the leftmost background is no longer in screen space, then it is repositioned to appear
    ///   after the rightmost background and the CurrentBackgroundIndex int is incremented.
    /// </summary>
    private void UpdateBackgroundPositions()
    {
	    foreach(var background in this.BackgroundObjects)
	    {
	        background.transform.Translate(-this.PlayerSpeed.Value * Time.deltaTime, 0f, 0f);
	    }
    }

    private void UpdateCurrentBackgroundIndex()
    {
	    Transform currentBackground = this.BackgroundObjects[this.CurrentBackgroundIndex].transform;
	    if(currentBackground.position.x < - Environment.Width)
	    {
	        currentBackground.position = new Vector3(currentBackground.position.x + (Environment.Width * this.BackgroundObjects.Length - 2), currentBackground.position.y, 0f);

	        this.CurrentBackgroundIndex++;
	    
	        if(this.CurrentBackgroundIndex == this.BackgroundObjects.Length)
	        {
		    this.CurrentBackgroundIndex = 0;
	        }
	    }
    }

    private void UpdateBackgroundSprites()
    {
	    foreach(var background in this.BackgroundObjects)
	    {
	        background.GetComponent<SpriteRenderer>().sprite = this.Environments[this.CurrentEnvironment].BackgroundSprite;
	    }
    }

    private void PositionFracture()
    {
	    Vector3 fracturePosition = this.FractureObject.transform.position;
	    fracturePosition.x = this.FractureDistance;
	
	    this.FractureObject.transform.position = fracturePosition;
    }

    private void UpdateFracturePosition()
    {
	    this.FractureObject.transform.Translate(-this.PlayerSpeed.Value * Time.deltaTime, 0f, 0f);
    }

    private void NextEnvironment()
    {
	    int next;

	    do
	    {
	        next = this.RandomEnvironment();
	    }
	    while(next == this.CurrentEnvironment);

	    this.CurrentEnvironment = next;
    }

    /// <summary>
    ///  Generates a random integer between the range 0 and Environments count
    /// </summary>
    /// <returns>An integer that is a valid index of the Environments list</returns>
    private int RandomEnvironment()
    {
	    return Random.Range(0, this.Environments.Count);
    }
}
