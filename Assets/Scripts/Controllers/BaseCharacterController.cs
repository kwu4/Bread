using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterController : MonoBehaviour
{
    protected Rigidbody2D r2d;
    protected BoxCollider2D boxCollider;
    public float speed, maxSpeed;
    private Animator animator;
    public int health, mana, experience, maxHealth, maxMana;

    protected virtual void Awake()
    {
        r2d = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();     
    }
  
    public void Move(Direction direction)
    {
        Vector2Int force = Vector2Int.zero;
        switch (direction)
        {
            case Direction.North:
                force = new Vector2Int(0, 1);
                if (r2d.velocity.y < 0)
                {
                    r2d.velocity = new Vector2(r2d.velocity.x, 0);
                }
                break;
            case Direction.South:
                force = new Vector2Int(0, -1);
                if (r2d.velocity.y > 0)
                {
                    r2d.velocity = new Vector2(r2d.velocity.x, 0);
                }
                break;
            case Direction.West:
                force = new Vector2Int(-1, 0);
                if (r2d.velocity.x > 0)
                {
                    r2d.velocity = new Vector2(0, r2d.velocity.y);
                }
                break;
            case Direction.East:
                force = new Vector2Int(1, 0);
                if (r2d.velocity.x < 0)
                {
                    r2d.velocity = new Vector2(0, r2d.velocity.y);
                }
                break;

        }
        animator.SetInteger("X", force.x);
        animator.SetInteger("Y", force.y);
        r2d.AddForce(new Vector2(force.x, force.y) * speed * Time.deltaTime);
    }

    public void StopMoving()
    {
        animator.SetInteger("X", 0);
        animator.SetInteger("Y", 0);
        r2d.velocity = Vector2.zero;
    }

    public void SetMaxHealthAndMaxMana(int maxHealth, int maxMana)
    {
        GameManager.instance.canvasController.UpdateHealthAndMana(maxHealth, maxMana);
    }

    public virtual void ChangeHealth(int change)
    {
        if (health + change == 0)
        {
            Die();
            return;
        }
        health += change;
        if (health > maxHealth) health = maxHealth;
        GameManager.instance.canvasController.UpdateHealthAndMana(health, mana);
    }

    public virtual void ChangeMana(int change)
    {
        if (mana == 0 && change == -1) return;
        mana += change;
        if (mana > maxMana) mana = maxMana;
        GameManager.instance.canvasController.UpdateHealthAndMana(health, mana);
    }

    public void Die()
    {

    }
}
