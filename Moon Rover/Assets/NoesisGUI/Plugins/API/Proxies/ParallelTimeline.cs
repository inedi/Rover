//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.10
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


using System;
using System.Runtime.InteropServices;

namespace Noesis
{

public class ParallelTimeline : TimelineGroup {
  internal new static ParallelTimeline CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new ParallelTimeline(cPtr, cMemoryOwn);
  }

  internal ParallelTimeline(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(ParallelTimeline obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  public ParallelTimeline() {
  }

  protected override IntPtr CreateCPtr(Type type, out bool registerExtend) {
    registerExtend = false;
    return NoesisGUI_PINVOKE.new_ParallelTimeline();
  }

  public static DependencyProperty SlipBehaviorProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.ParallelTimeline_SlipBehaviorProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public SlipBehavior SlipBehavior {
    set {
      NoesisGUI_PINVOKE.ParallelTimeline_SlipBehavior_set(swigCPtr, (int)value);
    } 
    get {
      SlipBehavior ret = (SlipBehavior)NoesisGUI_PINVOKE.ParallelTimeline_SlipBehavior_get(swigCPtr);
      return ret;
    } 
  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.ParallelTimeline_GetStaticType();
    return ret;
  }

}

}

