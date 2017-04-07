using ReactNative.UIManager;
using ReactNative.UIManager.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;

namespace ReactNativeSVG
{
    class ReactLineManager : ShapeViewManager<Line, ShapeShadowNode>
    {
        public override string Name
        {
            get
            {
                return "RCTLineView";
            }
        }

        public override void UpdateExtraData(Line root, object extraData)
        {

        }

        [ReactProp("x1")]
        public void setWidth(Line view, double x1)
        {
            view.X1 = x1;
        }


        [ReactProp("y1")]
        public void setHeight(Line view, double y1)
        {
            view.Y1 = y1;
        }


        [ReactProp("x2")]
        public void setRx(Line view, double x2)
        {
            view.X2 = x2;
        }

        [ReactProp("y2")]
        public void setRy(Line view, double y2)
        {
            view.Y2 = y2;
        }

        protected override Line CreateViewInstance(ThemedReactContext reactContext)
        {
            return new Line()
            {
                X1 = 0,
                Y1 = 0,
                X2 = 4f,
                Y2 = 4f,
                DataContext = new ShapeViewModel()
            };
        }

        public override ShapeShadowNode CreateShadowNodeInstance()
        {
            return new ShapeShadowNode();
        }

        public override void SetDimensions(Line view, Dimensions dimensions)
        {

        }
    }
}
