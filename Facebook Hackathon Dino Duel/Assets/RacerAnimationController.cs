using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMF;
//This script controls the character's animation by passing velocity values and other information ('isGrounded') to an animator component;
public class RacerAnimationController : MonoBehaviour
{
	public CharacterInput voiceInput;
	Controller controller;
	Animator animator;
	Transform animatorTransform;
	Transform tr;

	//Whether the character is using the strafing blend tree;
	public bool useStrafeAnimations = false;

	//Velocity threshold for landing animation;
	//Animation will only be triggered if downward velocity exceeds this threshold;
	public float landVelocityThreshold = 5f;

	private float smoothingFactor = 40f;
	Vector3 oldMovementVelocity = Vector3.zero;

	//Setup;
	void Awake()
	{
		voiceInput = GetComponent<CharacterInput>();
		controller = GetComponent<Controller>();
		animator = GetComponentInChildren<Animator>();
		animatorTransform = animator.transform;

		tr = transform;
	}

	//OnEnable;
	void OnEnable()
	{
		//Connect events to controller events;
		controller.OnLand += OnLand;
		controller.OnJump += OnJump;
	}

	//OnDisable;
	void OnDisable()
	{
		//Disconnect events to prevent calls to disabled gameobjects;
		controller.OnLand -= OnLand;
		controller.OnJump -= OnJump;
	}

	Vector3 pPosition;
	//Update;
	void Update()
	{

		//Get controller velocity;
		Vector3 _velocity = controller.GetVelocity();

		//Split up velocity;
		Vector3 _horizontalVelocity = VectorMath.RemoveDotVector(_velocity, tr.up);
		Vector3 _verticalVelocity = _velocity - _horizontalVelocity;

		//Smooth horizontal velocity for fluid animation;
		_horizontalVelocity = Vector3.Lerp(oldMovementVelocity, _horizontalVelocity, smoothingFactor * Time.deltaTime);
		oldMovementVelocity = _horizontalVelocity;

		Vector3 delta = (transform.position - pPosition);
        //float newSpeed = Mathf.MoveTowards(animator.GetFloat("Speed"), );

		//animator.SetFloat("Speed", voiceInput.GetHorizontalMovementInput()*voiceInput.GetHorizontalMovementInput() + voiceInput.GetVerticalMovementInput() * voiceInput.GetVerticalMovementInput() > 0.002f ? 1 : 0);
		//print(delta.magnitude);
		pPosition = transform.position;
		//Pass values to animator;
		animator.SetBool("IsGrounded", controller.IsGrounded());
		animator.SetBool("IsStrafing", useStrafeAnimations);
	}

	void OnLand(Vector3 _v)
	{
		//Only trigger animation if downward velocity exceeds threshold;
		if (VectorMath.GetDotProduct(_v, tr.up) > -landVelocityThreshold)
			return;

		animator.SetTrigger("OnLand");
	}

	void OnJump(Vector3 _v)
	{

	}
}
