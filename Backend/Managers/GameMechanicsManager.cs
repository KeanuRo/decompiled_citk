// Decompiled with JetBrains decompiler
// Type: Backend.Managers.GameMechanicsManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1AEE2D60-F9AC-4BB1-9F59-FC7C8812BBA8
// Assembly location: C:\Users\Киану\RiderProjects\SampleCitK2Mod\lib\Assembly-CSharp.dll

using Backend.Interfaces;
using System.Collections;
using UnityEngine;

#nullable disable
namespace Backend.Managers;

public class GameMechanicsManager : MonoBehaviour, IInitializable
{
  IEnumerator IInitializable.Initialize()
  {
    Object.DontDestroyOnLoad((Object) this.gameObject);
    foreach (Transform child in this.transform)
      yield return (object) this.StartCoroutine(child.GetComponent<IInitializable>().Initialize());
    yield return (object) null;
  }
}
