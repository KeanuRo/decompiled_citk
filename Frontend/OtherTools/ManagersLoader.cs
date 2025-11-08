// Decompiled with JetBrains decompiler
// Type: Frontend.OtherTools.ManagersLoader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Interfaces;
using Frontend.SceneLoadManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Frontend.OtherTools;

public class ManagersLoader : MonoBehaviour
{
  public List<MonoBehaviour> managers;
  [SerializeField]
  private Material quadMaterial;

  private void Awake()
  {
    this.quadMaterial.SetColor("_Color", Color.clear);
    this.StartCoroutine("Load");
  }

  private IEnumerator Load()
  {
    foreach (MonoBehaviour manager in this.managers)
      yield return (object) this.StartCoroutine(((IInitializable) manager).Initialize());
    this.EndLoading();
  }

  public void EndLoading() => SceneLoadManager.inst.LoadScene(1, 1f);
}
