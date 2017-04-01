using Facebook.Yoga;
using ReactNative.UIManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactNativeSVG
{
    class SVGShadowNode : LayoutShadowNode
    {
        public SVGShadowNode()
        {
            MeasureFunction = MeasureCanvas;
        }

        private static YogaSize MeasureCanvas(YogaNode node, float width, YogaMeasureMode widthMode, float height, YogaMeasureMode heightMode)
        {
            var adjustedHeight = YogaConstants.IsUndefined(height) ? 4f : height;
            var adjustedWidth = YogaConstants.IsUndefined(width) ? 4f : width;
            return MeasureOutput.Make(adjustedWidth, adjustedHeight);
        }
    }
}
