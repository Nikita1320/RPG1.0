using UnityEngine;

public abstract class BaseStateEnemy
{
    public abstract void Init(GameObject enemy);
    public abstract void Entry();
    public abstract void Update();
    public abstract void Exit();
}
