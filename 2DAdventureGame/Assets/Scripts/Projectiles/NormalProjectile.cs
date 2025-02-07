﻿using UnityEngine;
class NormalProjectile:Projectile,ITakeDamage
{
    public int Damage;
    public GameObject DestroyedEffect;
    public int PointsToGiveToPlyer;
    public float TimeToLive;

    public void Update()
    {
        if ((TimeToLive -= Time.deltaTime) <= 0)
        {
            DestroyProjectile();
            return;
        }
        //transform.Translate((Direction + new Vector2(InitialVelocity.x,0))*Speed*Time.deltaTime,Space.World);
        transform.Translate(Direction * (Mathf.Abs(InitialVelocity.x)+Speed) * Time.deltaTime, Space.World);

    }
    public void TakeDamage(int damage, GameObject instigator)
    {
        if(PointsToGiveToPlyer!=0)
        {
            var projectile = instigator.GetComponent<Projectile>();
            if(projectile!=null &&projectile.Owner.GetComponent<Player>()!=null)
            {
                GameManager.Instance.AddPoints(PointsToGiveToPlyer);
                FloatingText.Show(string.Format("+{0}!", PointsToGiveToPlyer), "PointStarText", new FromWorldPointTextPositioner(Camera.main, transform.position, 1.5f, 50));
            }
        }
        DestroyProjectile();
    }

    protected override void OnCollideOther(Collider2D other)
    {
        DestroyProjectile();
    }
    protected override void OnCollideTakeDamage(Collider2D other, ITakeDamage takeDamage)
    {
        takeDamage.TakeDamage(Damage, gameObject);
        DestroyProjectile();
    }
    private void DestroyProjectile()
    {
        if(DestroyedEffect != null)
            Instantiate(DestroyedEffect,transform.position,transform.rotation);
        Destroy(gameObject);
    }





    public void TakePeriodicDamage(int duration, int damage, GameObject instigator)
    {
        throw new System.NotImplementedException();
    }
}

