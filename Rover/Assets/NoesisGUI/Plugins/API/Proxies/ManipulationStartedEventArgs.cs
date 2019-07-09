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

public class ManipulationStartedEventArgs : InputEventArgs {
  private HandleRef swigCPtr;

  internal ManipulationStartedEventArgs(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(ManipulationStartedEventArgs obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~ManipulationStartedEventArgs() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NoesisGUI_PINVOKE.delete_ManipulationStartedEventArgs(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  internal static new void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args) {
    ManipulationStartedEventHandler handler_ = (ManipulationStartedEventHandler)handler;
    if (handler_ != null) {
      handler_(Extend.GetProxy(sender, false), new ManipulationStartedEventArgs(args, false));
    }
  }

  public UIElement ManipulationContainer {
    get {
      return GetManipulationContainerHelper();
    }
  }

  public Point ManipulationOrigin {
    get {
      IntPtr ret = NoesisGUI_PINVOKE.ManipulationStartedEventArgs_ManipulationOrigin_get(swigCPtr);
      if (ret != IntPtr.Zero) {
        return Marshal.PtrToStructure<Point>(ret);
      }
      else {
        return new Point();
      }
    }

  }

  public ManipulationStartedEventArgs(object s, RoutedEvent e, Visual manipulationContainer, Point manipulationOrigin) : this(NoesisGUI_PINVOKE.new_ManipulationStartedEventArgs(Noesis.Extend.GetInstanceHandle(s), RoutedEvent.getCPtr(e), Visual.getCPtr(manipulationContainer), ref manipulationOrigin), true) {
  }

  public bool Cancel() {
    bool ret = NoesisGUI_PINVOKE.ManipulationStartedEventArgs_Cancel(swigCPtr);
    return ret;
  }

  public void Complete() {
    NoesisGUI_PINVOKE.ManipulationStartedEventArgs_Complete(swigCPtr);
  }

  private UIElement GetManipulationContainerHelper() {
    IntPtr cPtr = NoesisGUI_PINVOKE.ManipulationStartedEventArgs_GetManipulationContainerHelper(swigCPtr);
    return (UIElement)Noesis.Extend.GetProxy(cPtr, false);
  }

}

}
