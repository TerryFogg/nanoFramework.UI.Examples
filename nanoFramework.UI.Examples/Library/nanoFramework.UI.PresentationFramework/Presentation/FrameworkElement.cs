//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.UI.Input;
using nanoFramework.Presentation.Media;
using nanoFramework.UI;
using System;
using System.Collections;
using System.Diagnostics;
using nanoFramework.Runtime.Events;
using nanoFramework.UI.Threading;

namespace nanoFramework.Presentation
{
    /// <summary>
    /// 
    /// </summary>
    public class FrameworkElement : UIElement
    {

        /// <summary>
        /// 
        /// </summary>
        public FrameworkElement() : base()
        {

        }

        /// <summary>
        ///  User defined data context associated with the FrameElement
        /// </summary>
        public object DataContext { get; set; }


    }


}

