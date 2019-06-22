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

public class StackPanel : Panel, Noesis.IScrollInfo {
  internal new static StackPanel CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new StackPanel(cPtr, cMemoryOwn);
  }

  internal StackPanel(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(StackPanel obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  public StackPanel() {
  }

  protected override IntPtr CreateCPtr(Type type, out bool registerExtend) {
    if (type == typeof(StackPanel)) {
      registerExtend = false;
      return NoesisGUI_PINVOKE.new_StackPanel();
    }
    else {
      return base.CreateExtendCPtr(type, out registerExtend);
    }
  }

  public void LineLeft() {
    NoesisGUI_PINVOKE.StackPanel_LineLeft(swigCPtr);
  }

  public void LineRight() {
    NoesisGUI_PINVOKE.StackPanel_LineRight(swigCPtr);
  }

  public void LineUp() {
    NoesisGUI_PINVOKE.StackPanel_LineUp(swigCPtr);
  }

  public void LineDown() {
    NoesisGUI_PINVOKE.StackPanel_LineDown(swigCPtr);
  }

  public void PageLeft() {
    NoesisGUI_PINVOKE.StackPanel_PageLeft(swigCPtr);
  }

  public void PageRight() {
    NoesisGUI_PINVOKE.StackPanel_PageRight(swigCPtr);
  }

  public void PageUp() {
    NoesisGUI_PINVOKE.StackPanel_PageUp(swigCPtr);
  }

  public void PageDown() {
    NoesisGUI_PINVOKE.StackPanel_PageDown(swigCPtr);
  }

  public void MouseWheelLeft(float delta) {
    NoesisGUI_PINVOKE.StackPanel_MouseWheelLeft__SWIG_0(swigCPtr, delta);
  }

  public void MouseWheelLeft() {
    NoesisGUI_PINVOKE.StackPanel_MouseWheelLeft__SWIG_1(swigCPtr);
  }

  public void MouseWheelRight(float delta) {
    NoesisGUI_PINVOKE.StackPanel_MouseWheelRight__SWIG_0(swigCPtr, delta);
  }

  public void MouseWheelRight() {
    NoesisGUI_PINVOKE.StackPanel_MouseWheelRight__SWIG_1(swigCPtr);
  }

  public void MouseWheelUp(float delta) {
    NoesisGUI_PINVOKE.StackPanel_MouseWheelUp__SWIG_0(swigCPtr, delta);
  }

  public void MouseWheelUp() {
    NoesisGUI_PINVOKE.StackPanel_MouseWheelUp__SWIG_1(swigCPtr);
  }

  public void MouseWheelDown(float delta) {
    NoesisGUI_PINVOKE.StackPanel_MouseWheelDown__SWIG_0(swigCPtr, delta);
  }

  public void MouseWheelDown() {
    NoesisGUI_PINVOKE.StackPanel_MouseWheelDown__SWIG_1(swigCPtr);
  }

  public void SetHorizontalOffset(float offset) {
    NoesisGUI_PINVOKE.StackPanel_SetHorizontalOffset(swigCPtr, offset);
  }

  public void SetVerticalOffset(float offset) {
    NoesisGUI_PINVOKE.StackPanel_SetVerticalOffset(swigCPtr, offset);
  }

  public Rect MakeVisible(Visual visual, Rect rect) {
    IntPtr ret = NoesisGUI_PINVOKE.StackPanel_MakeVisible(swigCPtr, Visual.getCPtr(visual), ref rect);
    if (ret != IntPtr.Zero) {
      return Marshal.PtrToStructure<Rect>(ret);
    }
    else {
      return new Rect();
    }
  }

  public static DependencyProperty OrientationProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.StackPanel_OrientationProperty_get();
      return (DependencyProperty)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  public Orientation Orientation {
    set {
      NoesisGUI_PINVOKE.StackPanel_Orientation_set(swigCPtr, (int)value);
    } 
    get {
      Orientation ret = (Orientation)NoesisGUI_PINVOKE.StackPanel_Orientation_get(swigCPtr);
      return ret;
    } 
  }

  public bool CanHorizontallyScroll {
    set {
      NoesisGUI_PINVOKE.StackPanel_CanHorizontallyScroll_set(swigCPtr, value);
    } 
    get {
      bool ret = NoesisGUI_PINVOKE.StackPanel_CanHorizontallyScroll_get(swigCPtr);
      return ret;
    } 
  }

  public bool CanVerticallyScroll {
    set {
      NoesisGUI_PINVOKE.StackPanel_CanVerticallyScroll_set(swigCPtr, value);
    } 
    get {
      bool ret = NoesisGUI_PINVOKE.StackPanel_CanVerticallyScroll_get(swigCPtr);
      return ret;
    } 
  }

  public float ExtentWidth {
    get {
      float ret = NoesisGUI_PINVOKE.StackPanel_ExtentWidth_get(swigCPtr);
      return ret;
    } 
  }

  public float ExtentHeight {
    get {
      float ret = NoesisGUI_PINVOKE.StackPanel_ExtentHeight_get(swigCPtr);
      return ret;
    } 
  }

  public float ViewportWidth {
    get {
      float ret = NoesisGUI_PINVOKE.StackPanel_ViewportWidth_get(swigCPtr);
      return ret;
    } 
  }

  public float ViewportHeight {
    get {
      float ret = NoesisGUI_PINVOKE.StackPanel_ViewportHeight_get(swigCPtr);
      return ret;
    } 
  }

  public float HorizontalOffset {
    get {
      float ret = NoesisGUI_PINVOKE.StackPanel_HorizontalOffset_get(swigCPtr);
      return ret;
    } 
  }

  public float VerticalOffset {
    get {
      float ret = NoesisGUI_PINVOKE.StackPanel_VerticalOffset_get(swigCPtr);
      return ret;
    } 
  }

  public ScrollViewer ScrollOwner {
    set {
      NoesisGUI_PINVOKE.StackPanel_ScrollOwner_set(swigCPtr, ScrollViewer.getCPtr(value));
    } 
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.StackPanel_ScrollOwner_get(swigCPtr);
      return (ScrollViewer)Noesis.Extend.GetProxy(cPtr, false);
    }
  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.StackPanel_GetStaticType();
    return ret;
  }

  internal new static IntPtr Extend(string typeName) {
    return NoesisGUI_PINVOKE.Extend_StackPanel(Marshal.StringToHGlobalAnsi(typeName));
  }
}

}
