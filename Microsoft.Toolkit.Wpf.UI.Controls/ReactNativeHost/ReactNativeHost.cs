// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Windows;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Microsoft.Toolkit.Wpf.UI.XamlHost;
using react.uwp;
using windows = Windows;

namespace Microsoft.Toolkit.Wpf.UI.Controls
{
    /// <summary>
    /// Wpf-enabled wrapper for <see cref="react.uwp.ReactControl"/>
    /// </summary>
    public class ReactNativeHost : WindowsXamlHostBase
    {
        internal react.uwp.ReactControl UwpControl => ChildInternal as react.uwp.ReactControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReactNativeHost"/> class, a
        /// Wpf-enabled wrapper for <see cref="react.uwp.ReactControl"/>
        /// </summary>
        public ReactNativeHost()
            : this(typeof(ReactControl).FullName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReactNativeHost"/> class, a
        /// Wpf-enabled wrapper for <see cref="react.uwp.ReactControl"/>.
        /// </summary>
        protected ReactNativeHost(string typeName)
            : base(typeName)
        {
        }

        /// <summary>
        /// Starts React Native <see cref="react.uwp.ReactControl"/>.
        /// </summary>
        public void StartReactNative(string javascriptFileName)
        {
            InstanceSettings settings = default(InstanceSettings);
            settings.UseLiveReload = true;
            settings.UseLiveReload = true;

            var instance = Instance.Create(javascriptFileName/*, modules*/);
            instance.RegisterModule(new Controls.SampleModule());
            instance.Start(settings);

            string initialProps = "{ "
                      + "\"accountUpn\":\"user@contoso.com\""
                      + ", \"accountType\":\"OrgId\""
                      + "}";

            UwpControl.InitialProps = initialProps;

            // TODO: Fix the hardcoded JS component name
            UwpControl.JsComponentName = "HardcodedJSComponentName";

            UwpControl.StartRender();
        }

        /// <inheritdoc />
        protected override void OnInitialized(EventArgs e)
        {
            // Initialize ReactNative here
            base.OnInitialized(e);
        }
    }
}