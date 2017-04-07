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
    class ReactRectManager : ShapeViewManager<Rectangle, ShapeShadowNode>
    {
        public override string Name
        {
            get
            {
                return "RCTRectView";
            }
        }

        public override void UpdateExtraData(Rectangle root, object extraData)
        {

        }

        [ReactProp("width")]
        public void setWidth(Rectangle view, double width)
        {
            view.Width = width;
        }


        [ReactProp("height")]
        public void setHeight(Rectangle view, double height)
        {
            view.Height = height;
        }


        [ReactProp("rx")]
        public void setRx(Rectangle view, double rx)
        {
            view.RadiusX = rx;
        }

        [ReactProp("ry")]
        public void setRy(Rectangle view, double ry)
        {
            view.RadiusY = ry;
        }

        protected override Rectangle CreateViewInstance(ThemedReactContext reactContext)
        {
            return new Rectangle()
            {
                Width = 4f,
                Height = 4f,
                RadiusX = 0,
                RadiusY = 0,
                DataContext = new ShapeViewModel()
            };
        }

        public override ShapeShadowNode CreateShadowNodeInstance()
        {
            return new ShapeShadowNode();
        }

        public override void SetDimensions(Rectangle view, Dimensions dimensions)
        {

        }
    }
}
