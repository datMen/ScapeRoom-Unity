using UnityEngine;
using System.Collections;

public abstract class EnemyState {
    protected Context context;

    public abstract void onEnter();
    public abstract void onUpdate();
    public abstract void onLeave();

    public abstract void startPatrol();
    public abstract void startDetected();
    public abstract void startAttackRanged();
    public abstract void startAttackMelee();
}