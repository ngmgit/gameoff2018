using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DefaultAnimParameters
{
	// Usual movements
	public static string Idle  	 = "idle";
	public static string Crouch  = "crouch";
	public static string Slide   = "slide";
	public static string Walk 	 = "walk";
	public static string WalkUp  = "walkUp";
	public static string Run     = "run";
	public static string Rush    = "rush";
	public static string Jump    = "jump";
	public static string Vanish  = "vanish";

	// jump variations
	public static string DoubleJump = "doubleJump";
	public static string Fall       = "fall";
	public static string WallRun    = "wallRun";
	public static string WallJump   = "wallJump";

	// Attack
	public static string Attack  = "attack";
	public static string AtkIdle = "atkIdle";

	// Hurt
	public static string Hurt      = "hurt";
	public static string KnockDown = "knockDown";
	public static string Recover   = "recover";
	public static string Dead      = "die";

	// other state
	public static string IsGrounded = "isGrounded";
	public static string InAir      = "inAir";
	public static string OnWall     = "onWall";
}