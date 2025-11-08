// Decompiled with JetBrains decompiler
// Type: Backend.OtherUtils.ReflectionUtils
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

#nullable disable
namespace Backend.OtherUtils;

public static class ReflectionUtils
{
  [MethodImpl(MethodImplOptions.NoInlining)]
  public static IEnumerable<Type> GetTypesByAttributes(Type T)
  {
    return ((IEnumerable<Type>) Assembly.GetAssembly(typeof (ReflectionUtils)).GetTypes()).Where<Type>((Func<Type, bool>) (t => t.IsDefined(T)));
  }
}
