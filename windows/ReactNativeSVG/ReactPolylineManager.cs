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
    class ReactPolylineManager : ShapeViewManager<Polyline, ShapeShadowNode>
    {
        public override string Name
        {
            get
            {
                return "RCTPolylineView";
            }
        }

        public override ShapeShadowNode CreateShadowNodeInstance()
        {
            return new ShapeShadowNode();
        }

        public override void UpdateExtraData(Polyline root, object extraData)
        {
         
        }

        public override void SetDimensions(Polyline view, Dimensions dimensions)
        {
            base.SetDimensions(view, dimensions);
        }

        [ReactProp("points")]
        public void setPoints(Polyline view, string points)
        {
            PointsParser pp = new PointsParser(points);
            view.Points = pp.getPoints();
        }

        [ReactProp("fillRule")]
        public void SetFillRule(Polygon view, string fillRule)
        {
            List<string> fillRuleArray = new List<string>() { " evenodd", "nonzero" };
            view.FillRule = (FillRule)fillRuleArray.IndexOf(fillRule);
    }

        protected override Polyline CreateViewInstance(ThemedReactContext reactContext)
        {
            return new Polyline()
            {
                FillRule = FillRule.EvenOdd
            };
        }
    }
}
