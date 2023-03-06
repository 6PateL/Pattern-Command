using UnityEngine;

public abstract class MoveCommand
{
  protected Transform transform;
  protected float stepDistance;
  
  public MoveCommand(Transform transform, float stepDistance = 1f)
  {
    this.stepDistance = stepDistance;
    this.transform = transform; 
  }
  
  public abstract void Execute();
  public abstract void Undo(); 
}
