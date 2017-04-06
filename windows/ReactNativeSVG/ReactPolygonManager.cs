using ReactNative.UIManager.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Shapes;
using ReactNative.UIManager;
using Windows.UI.Xaml.Media;

namespace ReactNativeSVG
{
    class ReactPolygonManager : ShapeViewManager<Polygon, ShapeShadowNode>
    {
        public override string Name
        {
            get
            {
                return "RCTPolygonView";
            }
        }

        public override ShapeShadowNode CreateShadowNodeInstance()
        {
            return new ShapeShadowNode();
        }

        public override void UpdateExtraData(Polygon root, object extraData)
        {

        }

        public override void SetDimensions(Polygon view, Dimensions dimensions)
        {
            base.SetDimensions(view, dimensions);
        }

        [ReactProp("points")]
        public void setWidth(Polygon view, string points)
        {
            PointsParser pp = new PointsParser(points);
            view.Points = pp.getPoints();
        }

        [ReactProp("fillRule")]
        public void SetFillRule(Polygon view, string fillRule)
        {
            // view.FillRule = fillRule == 0 ? FillRule.EvenOdd : FillRule.Nonzero;
        }

        protected override Polygon CreateViewInstance(ThemedReactContext reactContext)
        {
            return new Polygon()
            {
                FillRule = FillRule.EvenOdd
            };
        }
    }
}
