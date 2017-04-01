using ReactNative.UIManager;
using ReactNative.UIManager.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Shapes;

namespace ReactNativeSVG
{
    public class ReactLineManager : SimpleViewManager<Line>
    {
        public override string Name
        {
            get
            {
                return "RCTLineView";
            }
        }

        protected override Line CreateViewInstance(ThemedReactContext reactContext)
        {
            return new Line();
        }

        [ReactProp("x1")]
        public void SetX1(Line view, double x1)
        {
            view.Width = x1;
        }

        [ReactProp("y1")]
        public void SetY1(Line view, double y1)
        {
            view.Height = y1;
        }

        [ReactProp("x2")]
        public void SetX2(Line view, double x2)
        {
            view.Width = x2;
        }

        [ReactProp("y2")]
        public void SetY2(Line view, double y2)
        {
            view.Height = y2;
        }
    }
}
