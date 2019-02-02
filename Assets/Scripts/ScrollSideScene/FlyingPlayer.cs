using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase construida para representar al juggador en el juego.
public class FlyingPlayer : MonoBehaviour {
	//Atributos
	private double life;
	private float vel;
	private double pos_x;
	private double pos_y;
	public static string greeting;

	//Constructor
	public FlyingPlayer(){
		life = 10;
		vel = 0.5f;
	}
	//Static constructor to initialize static members
	static FlyingPlayer (){
		greeting = "I'm a chicken!";
	}

	public double getLife(){
		return this.life;
	}
	public void setLife(double life){
		this.life = life;
	}

	public float getVel(){
		return this.vel;
	}
	public void setVel(float vel){
		this.vel = vel;
	}
	public double getPosX(){
		return this.pos_x;
	}
	public void setPosX(double pos_x){
		this.pos_x = pos_x;
	}
	public double getPosY(){
		return this.pos_y;
	}
	public void setPosY(double pos_y){
		this.pos_y = pos_y;
	}

	//Methods
	public void moveUp(){
		this.pos_y = this.pos_y + 1;
	}
	public void moveDown(){
		this.pos_y = this.pos_y - 1;
	}

	public void move(Rigidbody2D rgb){
		rgb.velocity = new Vector2 (0, this.vel);

	}

	
}
