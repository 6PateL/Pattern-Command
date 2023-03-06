using UnityEngine;

public class MoveDiagonalCommand : MoveCommand
{
    private Vector3 directionDiagonal = new Vector3(1f,-1f,0f).normalized;
    
    public MoveDiagonalCommand(Transform transform, float stepDistance = 1) : base(transform, stepDistance)
    {
        
    }

    public override void Execute()
    {
        transform.position += directionDiagonal * stepDistance;   
    }
    public override void Undo()
    { 
        transform.position -= directionDiagonal * stepDistance; 
    }     
}
