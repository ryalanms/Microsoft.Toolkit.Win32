using System;
using System.Collections.Generic;
using System.Text;
using react.uwp;

namespace Microsoft.Toolkit.Wpf.UI.Controls
{
    public class SampleModule : IModule
    {
        private Dictionary<string, string> _constants;
        private Dictionary<string, MethodDelegate> delegates = new Dictionary<string, MethodDelegate>();
        private Dictionary<string, MethodWithCallbackDelegate> delegateWithCallback = new Dictionary<string, MethodWithCallbackDelegate>();

        public SampleModule()
        {
            _constants = new Dictionary<string, string>();
            _constants.Add("a", "\"b\"");

            delegates.Add("method1", new MethodDelegate(
              (string para) =>
              {
              }));

            delegateWithCallback.Add("method2", new MethodWithCallbackDelegate(
              (string para, MethodCallback callback) =>
              {
                  string[] results = new string[] { "{ \"result\":true }" };
                  callback(results);
              }));
        }

        public IReadOnlyDictionary<string, string> Constants
        {
            get
            {
                return _constants;
            }
        }

        public IReadOnlyDictionary<string, MethodDelegate> Methods
        {
            get
            {
                return delegates;
            }
        }

        public IReadOnlyDictionary<string, MethodWithCallbackDelegate> MethodsWithCallback
        {
            get
            {
                return delegateWithCallback;
            }
        }

        public string Name
        {
            get
            {
                return "SampleModule";
            }
        }
    }
}