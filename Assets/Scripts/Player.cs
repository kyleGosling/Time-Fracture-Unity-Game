using UnityEngine;


public class Player : MonoBehaviour
{
    public LevelCreator LevelCreator;
    public FloatReference Speed;
    public IntReference Lives;
    public float MaxSpeed;

    
    public void OnCollisionEnter2D(Collision2D other)
    {
	    this.LevelCreator.CreateNextEnvironment();
	    this.Speed.Value += 1f;
	    this.Lives.Value += 1;
    }

    
}


