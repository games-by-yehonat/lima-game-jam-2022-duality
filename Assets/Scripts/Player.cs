using UnityEngine;

public class Player : MovingObject
{
	public float restartLevelDelay = 1f;
	public int pointsPerFood = 10;
	public int pointsPerSoda = 20;
	public int wallDamage = 1;
    
	private Animator m_animator;
	private int m_food;
	
    
	protected override void Start ()
	{
		m_animator = GetComponent<Animator>();

		// m_food = GameManager.instance.playerFoodPoints;

		base.Start ();
	}
    
	private void Update ()
	{
		// if(!GameManager.instance.playersTurn) return;
		if (!m_turn)
		{
			return;
		}
		
		

		int horizontal = 0;
		int vertical = 0;
        
		horizontal = (int) (Input.GetAxisRaw ("Horizontal"));
		vertical = (int) (Input.GetAxisRaw ("Vertical"));
        
		if(horizontal != 0)
		{
			vertical = 0;
		}
        
		if(horizontal != 0 || vertical != 0)
		{
			AttemptMove<Wall> (horizontal, vertical);
		}
	}
    
	protected override void AttemptMove <T> (int xDir, int yDir)
	{
		// food--;
        
		base.AttemptMove <T> (xDir, yDir);
		RaycastHit2D hit;
        
		if (Move (xDir, yDir, out hit)) 
		{
			//Call RandomizeSfx of SoundManager to play the move sound, passing in two audio clips to choose from.
		}
        
		// CheckIfGameOver ();
        
		// GameManager.instance.playersTurn = false;
		// m_turn = false;
	}
    
	protected override void OnCantMove<T>(T component)
	{
		Wall hitWall = component as Wall;
        
		// hitWall.DamageWall (wallDamage);
        
		// animator.SetTrigger ("playerChop");
	}
}