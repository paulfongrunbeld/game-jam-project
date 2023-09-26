using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorSetter : MonoBehaviour
{
    [SerializeField] private List<BaseBehavior> behaviorsList;
    [SerializeField] private BaseBehavior currentBehavior;
    [SerializeField] private Animator anim;
    
    private enum Behaviors
    {
        Idle,
        Runing,
        MelleAttack,
        Dash
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
           GetComponent<IdlePlayerBehavior>(),
           GetComponent<RunPlayerBehavior>(),
           GetComponent<MelleAttackPlayerBehavior>(),
           GetComponent<DashPlayerBehavior>()
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

    public void SetBehaviorRuning()
    {
        var behavior = behaviorsList[(int)Behaviors.Runing];
        Behavior = Behaviors.Runing;
        this.SetBehavior(behavior);
    }

    public void SetBehaviorIdle()
    {
        var behavior = behaviorsList[(int)Behaviors.Idle];
        Behavior = Behaviors.Idle;
        this.SetBehavior(behavior);
    }

    public void SetbehaviorMeleeAttack()
    {
        var behavior = behaviorsList[(int)Behaviors.MelleAttack];
        Behavior = Behaviors.MelleAttack;
        this.SetBehavior(behavior);
    }
    public void SetbehaviorDash()
    {
        var behavior = behaviorsList[(int)Behaviors.Dash];
        Behavior = Behaviors.Dash;
        this.SetBehavior(behavior);
    }
}
