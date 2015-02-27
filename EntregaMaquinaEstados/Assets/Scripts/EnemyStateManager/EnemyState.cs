using UnityEngine;
using System.Collections;

public abstract class EnemyState {
    public abstract void onEnter();
    public abstract void onUpdate();
    public abstract void onLeave();


    public abstract void Patrol();
    public abstract void Attack();
}