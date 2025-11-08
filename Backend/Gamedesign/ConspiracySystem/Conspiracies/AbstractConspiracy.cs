// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.ConspiracySystem.Conspiracies.AbstractConspiracy
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using System;
using System.Reflection;

#nullable disable
namespace Backend.Gamedesign.ConspiracySystem.Conspiracies;

public abstract class AbstractConspiracy
{
  public ConspiracyType Type
  {
    get
    {
      return ((ConspiracyAttribute) Attribute.GetCustomAttribute((MemberInfo) this.GetType(), typeof (ConspiracyAttribute))).type;
    }
  }

  public abstract bool AvalibleForPlayer { get; }

  public abstract (bool, string) GetStatusAndDescriptionForPlayer(
    GameState gameState,
    Characters target);

  public virtual bool GetConditionsToStop(GameState gameState, ConspiracyInfo conspiracyInfo)
  {
    return conspiracyInfo.members.Count == 0 || conspiracyInfo.leader.HasValue && gameState.characters[conspiracyInfo.leader.Value].status != CharacterInfo.PoliticStatus.Alive;
  }

  public abstract bool GetConditionsToSucced(GameState gameState, ConspiracyInfo conspiracyInfo);

  public virtual void EndConspiracy(
    GameState gameState,
    ConspiracyInfo conspiracyInfo,
    bool wasSuccessful)
  {
    if (!wasSuccessful && (double) conspiracyInfo.power < 0.0 && conspiracyInfo.conspiracyPoliticTarget.HasValue && conspiracyInfo.leader.HasValue)
    {
      Characters? leader = conspiracyInfo.leader;
      Characters gameCharacter = gameState.gameCharacter;
      if (leader.GetValueOrDefault() == gameCharacter & leader.HasValue)
      {
        gameState.characters[conspiracyInfo.conspiracyPoliticTarget.Value].knownTraitors.Add(gameState.gameCharacter);
      }
      else
      {
        gameState.characters[conspiracyInfo.leader.Value].Stress += 15f;
        gameState.characters[conspiracyInfo.conspiracyPoliticTarget.Value].knownTraitors.Add(conspiracyInfo.leader.Value);
      }
    }
    gameState.conspiracies.Remove(conspiracyInfo);
  }

  public abstract int GetPowerChange(GameState gameState, ConspiracyInfo conspiracyInfo);
}
