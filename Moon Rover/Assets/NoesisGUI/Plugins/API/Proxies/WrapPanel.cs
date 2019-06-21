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

public class WrapPanel : Panel {
  internal new static WrapPanel CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new WrapPanel(cPtr, cMemoryOwn);
  }

  internal WrapPanel(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(WrapPanel obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  public WrapPanel() {
  }

  protected override IntPtr CreateCPtr(Type type, out bool registerExtend) {
    if (type == typeof(WrapPanel)) {
      registerExtend = false;
      return NoesisGUI_PINVOKE.new_WrapPanel();
    }
    else {
      return base.CreateExtendCPtr(type, out registerExtend);
    }
  }

  public static DependencyProperty ItemWidthProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.WrapPanel_ItemWidthProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty ItemHeightProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.WrapPanel_ItemHeightProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public static DependencyProperty OrientationProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.WrapPanel_OrientationProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public float ItemWidth {
    set {
      NoesisGUI_PINVOKE.WrapPanel_ItemWidth_set(swigCPtr, value);
    } 
    get {
      float ret = NoesisGUI_PINVOKE.WrapPanel_ItemWidth_get(swigCPtr);
      return ret;
    } 
  }

  public float ItemHeight {
    set {
      NoesisGUI_PINVOKE.WrapPanel_ItemHeight_set(swigCPtr, value);
    } 
    get {
      float ret = NoesisGUI_PINVOKE.WrapPanel_ItemHeight_get(swigCPtr);
      return ret;
    } 
  }

  public Orientation Orientation {
    set {
      NoesisGUI_PINVOKE.WrapPanel_Orientation_set(swigCPtr, (int)value);
    } 
    get {
      Orientation ret = (Orientation)NoesisGUI_PINVOKE.WrapPanel_Orientation_get(swigCPtr);
      return ret;
    } 
  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.WrapPanel_GetStaticType();
    return ret;
  }

  internal new static IntPtr Extend(string typeName) {
    return NoesisGUI_PINVOKE.Extend_WrapPanel(Marshal.StringToHGlobalAnsi(typeName));
  }
}

}

