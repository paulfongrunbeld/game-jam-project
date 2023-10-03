using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormBehaviorSetter : MonoBehaviour
{
    [SerializeField] private List<BaseBehavior> behaviorsList;
    [SerializeField] private BaseBehavior currentBehavior;
    [SerializeField] private Animator anim;

    private enum Behaviors
    {
        Idle,
        Walk,
        RangeAttack,
        Hit,
        Death
    }
    private Behaviors Behavior
    {
        get { return (Behaviors)anim.GetInteger("behavior"); }
        set { anim.SetInteger("behavior", (int)value); }
    }


    private void Awake()
    {

        anim = GetComponent<Animator>();
        behaviorsList = new List<BaseBehavior>()
        {
           GetComponent<IdleWormBehavior>(),
           GetComponent<WalkWormBehavior>(),
           GetComponent<AttackWormBehavior>(),
           GetComponent<HitWormBehavior>(),
           GetComponent<DeathWormBehavior>(),
        };
        SetBehaviorIdle();
    }

    private void SetBehavior(BaseBehavior newBehavior)
    {
        if (this.currentBehavior != null) this.currentBehavior.Exit();
        this.currentBehavior = newBehavior;
        currentBehavior.enabled = true;
        this.currentBehavior.Enter();
    }
    private void Update()
    {
        if (this.currentBehavior != null) this.currentBehavior.Update();
    }

    public void SetBehaviorWalk()
    {
        var behavior = behaviorsList[(int)Behaviors.Walk];
        Behavior = Behaviors.Walk;
        this.SetBehavior(behavior);
    }

    public void SetBehaviorIdle()
    {
        var behavior = behaviorsList[(int)Behaviors.Idle];
        Behavior = Behaviors.Idle;
        this.SetBehavior(behavior);
    }

    public void SetBehaviorRangeAttack()
    {
        var behavior = behaviorsList[(int)Behaviors.RangeAttack];
        Behavior = Behaviors.RangeAttack;
        this.SetBehavior(behavior);
    }
    public void SetbehaviorHit()
    {
        var behavior = behaviorsList[(int)Behaviors.Hit];
        Behavior = Behaviors.Hit;
        this.SetBehavior(behavior);
    }

    public void SetBehaviorDeath()
    {
        var behavior = behaviorsList[(int)Behaviors.Hit];
        Behavior = Behaviors.Hit;
        this.SetBehavior(behavior);
    }
}
