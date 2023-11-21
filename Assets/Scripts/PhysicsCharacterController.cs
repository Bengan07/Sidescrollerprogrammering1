using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;


public enum CharacterState
{
    Grounded,
    Jumping,
    Airborne
}

public class PhysicsCharacterController : MonoBehaviour
{
    //Refrence to rigidbody on same object
    public Rigidbody2D myRigidBody = null;

    public CharacterState JumpingState = CharacterState.Airborne;
    //Is Our character on the ground or in the air?

    //Gravity
    public float GravityPerSecond = 160.0f; //Falling Speed
    public float GroundLevel = 0.0f; //Ground Value

    //Jump 
    public float JumpSpeedFactor = 3.0f; //How much faster is the jump than the movespeed?
    public float JumpMaxHeight = 150.0f;
    //How far have we flew this jump?
    public float JumpHeightDelta = 0.0f;

    //Movement
    public float MovementSpeedPerSecond = 10.0f; //Movement Speed


    public int HP = 1;
    public SpriteRenderer mySpriteRender = null;
    public List<Sprite> CharacterSprite = new List<Sprite>();
    public SceneLoader mySceneloader = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && JumpingState == CharacterState.Grounded)
        {
            JumpingState = CharacterState.Jumping; //Set character to jumping
            JumpHeightDelta = 0.0f; //Restart Counting Jumpdistance
        }

        int hpCopy = HP - 1;
        if (hpCopy < 0)
        { 
            hpCopy = 0; 
        }
        if (hpCopy >= CharacterSprite.Count)
        {
            hpCopy = CharacterSprite.Count - 1;
        }

        mySpriteRender.sprite = CharacterSprite[hpCopy];

    }

    void FixedUpdate()
    {
        Vector3 characterVelocity = myRigidBody.velocity;
        characterVelocity.x = 0.0f;

        if (JumpingState == CharacterState.Jumping)
        {
            float jumpMovement = MovementSpeedPerSecond * JumpSpeedFactor;
            characterVelocity.y = jumpMovement;

            JumpHeightDelta += jumpMovement * Time.deltaTime;

            if (JumpHeightDelta >= JumpMaxHeight)
            {
                JumpingState = CharacterState.Airborne;
                characterVelocity.y = 0;

            }
        }

        //Left
        if (Input.GetKey(KeyCode.A))
        {
            characterVelocity.x -= MovementSpeedPerSecond;
        }
        //Right
        if (Input.GetKey(KeyCode.D))
        {
            characterVelocity.x += MovementSpeedPerSecond;
        }
        myRigidBody.velocity = characterVelocity;

    }

    public void TakeDamage(int aHPValue)
    {
        HP += aHPValue;
        if(HP < 0)
        {
            mySceneloader.LoadScene("Start Main");
        }
    }

}
