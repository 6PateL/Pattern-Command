using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
  [SerializeField] private Button _buttonStraight;
  [SerializeField] private Button _buttonDiagonal;
  [SerializeField] private Button _buttonUndo;
  [SerializeField] private Transform pivotTransform;
  [SerializeField] private float stepDistance = 1f;
  private List<MoveCommand> _moveJournal = new List<MoveCommand>(); 

  private void OnEnable()
  {
    _buttonStraight.onClick.AddListener(StepStraight);
    _buttonDiagonal.onClick.AddListener(StepDiagonal);
    _buttonUndo.onClick.AddListener(Undo);
  }

  private void OnDisable()
  {
    _buttonStraight.onClick.RemoveListener(StepStraight);
    _buttonDiagonal.onClick.RemoveListener(StepDiagonal);
    _buttonUndo.onClick.RemoveListener(Undo);
  }

  private void StepStraight()
  {
    var move = new MoveStraightCommand(pivotTransform, stepDistance);
    move.Execute();
    _moveJournal.Add(move);
  }
  private void StepDiagonal()
  {
    var move = new MoveDiagonalCommand(pivotTransform, stepDistance);
    move.Execute();
    _moveJournal.Add(move);
  }
  private void Undo()
  {
    if(_moveJournal.Count > 0) {
      var LastMove = _moveJournal.Last();
      LastMove.Undo();
      _moveJournal.Remove(LastMove);
    }
  }
}
