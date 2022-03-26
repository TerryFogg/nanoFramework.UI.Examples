//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;
using nanoFramework.Runtime.Events;

namespace nanoFramework.UI
{
    /// <summary>  </summary>
    [FlagsAttribute]
    public enum TouchInputFlags : uint
    {
        /// <summary>  </summary>

        None = 0x00,

        /// <summary>  </summary>
        Primary = 0x0010,  //The Primary flag denotes the input that is passed to the single-touch Stylus events provided

        //no controls handle the Touch events.  This flag should be set on the TouchInput structure that represents
        //the first finger down as it moves around up to and including the point it is released.

        /// <summary>  </summary>
        Pen = 0x0040,     //Hardware support is optional, but providing it allows for potentially richer applications.

        /// <summary>  </summary>
        Palm = 0x0080,     //Hardware support is optional, but providing it allows for potentially richer applications.
    }

    ///
    /// IMPORTANT - This must be in sync with code in PAL and also nanoFramework
    ///
    /// <summary>  </summary>
    public enum TouchMessages : byte
    {
        /// <summary>  </summary>
        Down = 1,
        /// <summary>  </summary>
        Up = 2,
        /// <summary>  </summary>
        Move = 3,
    }

    /// <summary>  </summary>
    public class TouchCoordinate
    {
        /// <summary> X coordinate of touch point </summary>
        public int X;
        /// <summary> Y coordinate of touch point </summary>
        public int Y;
        /// <summary> SourceID </summary>
        public byte SourceID;
        /// <summary> TouchInputFlags </summary>
        public TouchInputFlags Flags;
        /// <summary> ContactWidth </summary>
        public uint ContactWidth;
        /// <summary> ContactHeight </summary>
        public uint ContactHeight;
    }

    /// <summary>  </summary>
    /// <summary>  </summary>
    public enum TouchGesture : uint
    {
        /// <summary> Gestures only generated on touch up </summary>
        NoGesture = 0,
        /// <summary> Right </summary>
        Right = 1,
        /// <summary> Up Right </summary>
        UpRight = 2,
        /// <summary> Up </summary>
        Up = 3,
        /// <summary> Up Left </summary>
        UpLeft = 4,
        /// <summary> Left </summary>
        Left = 5,
        /// <summary> Down Left </summary>
        DownLeft = 6,
        /// <summary> Down </summary>
        Down = 7,
        /// <summary> Down Right </summary>
        DownRight = 8
    }

    /// <summary> TouchGestureVelocity </summary>
    public enum TouchGestureVelocity : uint
    {
        /// <summary> Slow </summary>
        Slow = 0,
        /// <summary> Medium </summary>
        Medium = 1,
        /// <summary> Fast </summary>
        Fast = 2
    }

    /// <summary>  </summary>
    public class TouchEvent : BaseEvent
    {
        /// <summary>  </summary>
        public DateTime Time;
        /// <summary>  </summary>
        public TouchCoordinate Touches;
        /// <summary>  </summary>
        public TouchGesture TouchGesture;
    }

    /// <summary>
    /// 
    /// </summary>
    public class TouchScreenEventArgs : EventArgs
    {
        // Fields
        /// <summary>  </summary>
        public TouchCoordinate Touches;
        /// <summary>  </summary>
        public DateTime TimeStamp;
        /// <summary>  </summary>
        public object Target;

        // Methods
    /// <summary>
    /// 
    /// </summary>
    /// <param name="timestamp"></param>
    /// <param name="touches"></param>
    /// <param name="target"></param>
        public TouchScreenEventArgs(DateTime timestamp, TouchCoordinate touches, object target)
        {
            this.Touches = touches;
            this.TimeStamp = timestamp;
            this.Target = target;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="touchIndex"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void GetPosition(int touchIndex, out int x, out int y)
        {
            x = Touches.X;
            y = Touches.Y;
        }
    }

    //--//

    /// <summary>  </summary>
    public delegate void TouchScreenEventHandler(object sender, TouchScreenEventArgs e);

    //--//

    /// <summary>  </summary>
    public class TouchGestureEventArgs : EventArgs
    {
        /// <summary> Gesture </summary>
        public TouchGesture Gesture;

        /// <summary> velocity </summary>
        public TouchGestureVelocity Velocity;

        /// <summary> TouchGestureEventArgs </summary>
        public TouchGestureEventArgs(TouchGesture Gesture, TouchGestureVelocity velocity)
        {
            this.Gesture = Gesture;
            this.Velocity = velocity;
        }

    }

    //--//

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void TouchGestureEventHandler(object sender, TouchGestureEventArgs e);

    internal class TouchEventProcessor : IEventProcessor
    {
        public BaseEvent ProcessEvent(uint flags, uint touchPointCombined, DateTime time)
        {
            Int16 data = (Int16)(flags << 16);                          // Bits 31...16
            byte category = (byte)(flags >> 8);                         // Bits 15...8
            TouchMessages touchState = (TouchMessages)(byte)flags;      // Bits  7...0

            int x1 = (Int16)(touchPointCombined);                       // Bits 15...0
            int y1 = (Int16)((touchPointCombined >> 16) & 0x1FFF);      // Bits 31...16
            TouchCoordinate touches = new TouchCoordinate { X = x1, Y = y1};
            TouchGesture touchGesture = (TouchGesture)(flags >> 16);

            return new TouchEvent
            {
                Touches = touches,
                Message = (byte)touchState,
                Source = 1,
                TouchGesture = touchGesture,
                Time = time
            };
        }
    }

    /// <summary>  </summary>
    public static class Touch
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="touchEventListener"></param>
        [MethodImplAttribute(MethodImplOptions.Synchronized)]
        public static void Initialize(IEventListener touchEventListener)
        {
            if (_initialized)
                return;

            // Activates event detection from the touch device
            if(_activeTouchPanel == null)
            {
                _activeTouchPanel = new TouchPanel();
            }
            _activeTouchPanel.Enabled = true;

            // Add a touch event processor.
            EventSink.AddEventProcessor(EventCategory.Touch, new TouchEventProcessor());

            // Start the event sink process. This will pump
            // events neatly out of the other world.
            EventSink.AddEventListener(EventCategory.Touch, touchEventListener);

            _initialized = true;
        }

        /// <summary>  </summary>
        //public static TouchPanel ActiveTouchPanel
        //{
        //    get
        //    {
        //        return _activeTouchPanel;
        //    }
        //}

        private static bool _initialized = false;
        private static TouchPanel _activeTouchPanel = null;
    }
}


