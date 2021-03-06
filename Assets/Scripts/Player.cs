﻿using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

  private Rigidbody2D rb;

  public float thrust = 1f;
  public float dashMultiplier = 10f;
  public ForceMode2D mode = ForceMode2D.Force;

  public float speed = 1;
  public int attack = 1;
  public int health = 1;
  private float invulnerabilityTimer = 0;

  public int maxStamina = 1;
  public float stamina = 1f;
  public float dashStaminaCost = 1f;

  public float airGravityScale = 50f;

  public List<SkeletonAnimation> speedControlledAnimations = new List<SkeletonAnimation>();
  public List<Animator> speedControlledAnimators = new List<Animator>();

  // player jumps out of water, or reinters water
  public AudioClip[] splashSounds;

  // hit dash button
  public AudioClip[] dashSounds;

  // Player uses bite or poke attacks
  public AudioClip[] biteSounds;
  public AudioClip[] pokeSounds;

  // Player is hit by enemy
  public AudioClip[] hitSounds;

  void Start() {
    rb = GetComponent<Rigidbody2D>();
    stamina = maxStamina;
  }

  Vector2 direction = new Vector2();

  void FixedUpdate() {
    var horizontal = Input.GetAxis("Horizontal");
    var vertical = Input.GetAxis("Vertical");

    var amt = thrust * speed;

    direction = new Vector2();
    if (horizontal < 0) {
      direction += Vector2.left;
    }
    if (horizontal > 0) {
      direction += Vector2.right;
    }
    if (transform.position.y < 0) {
      if (vertical < 0) {
        direction += Vector2.down;
      }
      if (vertical > 0) {
        direction += Vector2.up;
      }

      if (Input.GetButtonDown("dash") && stamina >= dashStaminaCost) {
        SoundManager.instance.Play(dashSounds);
        stamina -= dashStaminaCost;
        amt *= dashMultiplier;
      }

      rb.gravityScale = 0;
    } else {
      rb.gravityScale = airGravityScale;
    }
    direction = direction.normalized;

    rb.AddForce(direction * amt, mode);
  }

  void Update() {
    if (Input.GetKeyDown("t")) {
      SceneManager.LoadScene("Title");
    }
    if (Input.GetKeyDown("u")) {
      SceneManager.LoadScene("Upgrade");
    }

    invulnerabilityTimer = Mathf.Max(0f, invulnerabilityTimer - Time.deltaTime);

    var scale = transform.localScale;
    if ((direction.x > 0.01 || direction.x < -0.01) && Mathf.Sign(direction.x) != Mathf.Sign(scale.x)) {
      scale.x = -scale.x;
    }
    transform.localScale = scale;

    var angleZ = rb.velocity.y / 2000f * 45f;
    if (scale.x < 0) {
      angleZ *= -1;
    }
    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angleZ), 0.5f);

    var animationSpeed = 0.5f + (rb.velocity.magnitude / 2000f);
    foreach (var anim in speedControlledAnimations) {
      anim.timeScale = animationSpeed;
    }
    foreach (var anim in speedControlledAnimators) {
      anim.speed = animationSpeed;
    }
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    /* Debug.Log(collision.gameObject.tag); */
    if (collision.gameObject.tag == "Hazard") {
      rb.velocity *= -1;
      rb.AddForce((collision.relativeVelocity * -1).normalized * thrust * speed * dashMultiplier * 5, ForceMode2D.Impulse);
      if (invulnerabilityTimer <= 0) {
        health--;
        invulnerabilityTimer = 3f;
        if (health <= 0) {
          SceneManager.LoadScene("Main");
        }
      }
    } else if (collision.gameObject.tag == "Eggs") {
      SceneManager.LoadScene("Upgrade");
    }
  }

  protected void OnGUI()
  {
    GUI.skin.label.fontSize = Screen.width / 40;
    GUILayout.Label(GameManager.Instance.currentName);
    GUILayout.Label(string.Format("Stamina: {0} / {1}", stamina, maxStamina));
    GUILayout.Label(string.Format("Health: {0}", health));
    GUILayout.Label(string.Format("Speed: {0}", speed));
    GUILayout.Label(string.Format("Attack: {0}", attack));
  }
}
