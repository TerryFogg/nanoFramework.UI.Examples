//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System.Runtime.CompilerServices;

namespace nanoFramework.UI
{
    /// <summary>
    /// 
    /// </summary>
    public class TouchPanel
    {
        private bool _enabled = false;
        /// <summary>
        ///  Enable or disable the touch detection of the touch controller hardware
        /// </summary>
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                EnableInternal(value);
                _enabled = value;
            }
        }
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        private extern void EnableInternal(bool enable);


    }
}


