

using Facebook.Yoga;
using Newtonsoft.Json.Linq;
using ReactNative.UIManager;
using ReactNative.UIManager.Annotations;
using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace ReactNativeSVG
{
    class ShapeShadowNode : LayoutShadowNode
    {
        public ShapeShadowNode()
        {
            MeasureFunction = MeasureShape;
        }

        private static YogaSize MeasureShape(YogaNode node, float width, YogaMeasureMode widthMode, float height, YogaMeasureMode heightMode)
        {
            var adjustedHeight = YogaConstants.IsUndefined(height) ? 4f : height;
            var adjustedWidth = YogaConstants.IsUndefined(width) ? 4f : width;
            return MeasureOutput.Make(adjustedWidth, adjustedHeight);
        }
    }
}
