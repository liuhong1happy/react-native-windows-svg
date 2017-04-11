using ReactNative.UIManager;
using Windows.UI.Xaml.Controls;
using ReactNative.UIManager.Annotations;
using Windows.UI.Xaml;
using System;
using Windows.Foundation;
using Windows.UI.Xaml.Media;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml.Shapes;
using Newtonsoft.Json.Linq;

namespace ReactNativeSVG
{
    class ReactGroupManager : GroupViewManager<Canvas, SVGShadowNode>
    {
        public override string Name
        {
            get
            {
                return "RCTGroupView";
            }
        }

        public override void AddView(Canvas parent, DependencyObject child, int index)
        {
            ShapeViewModel childViewModel = (ShapeViewModel)((Shape)child).DataContext;
            ShapeViewModel parentViewModel = (ShapeViewModel)parent.DataContext;

            List<String> parentUpdateKeys = parentViewModel.UpdateKeys;
            List<String> childUpdateKeys = childViewModel.UpdateKeys;
            List<String> canUpdateKeys = new List<String>() {
                "stroke","strokeWidth", "strokeOpacity","strokeLinecap","strokeLinejoin","strokeDasharray","strokeDashoffset","strokeMiterlimit","fill","fillOpacity"
            };
            parentUpdateKeys.ForEach((str) =>
            {
                if (childUpdateKeys.IndexOf(str) == -1 && canUpdateKeys.IndexOf(str) != -1)
                {
                    switch (str)
                    {
                        case "stroke":
                            childViewModel.Stroke = parentViewModel.Stroke;
                            break;
                        case "strokeWidth":
                            childViewModel.StrokeThickness = parentViewModel.StrokeThickness;
                            break;
                        case "strokeOpacity":
                            childViewModel.StrokeOpacity = parentViewModel.StrokeOpacity;
                            break;
                        case "strokeLinecap":
                            childViewModel.StrokeLinecap = parentViewModel.StrokeLinecap;
                            break;
                        case "strokeLinejoin":
                            childViewModel.StrokeLinejoin = parentViewModel.StrokeLinejoin;
                            break;
                        case "strokeDasharray":
                            childViewModel.StrokeDashArray = parentViewModel.StrokeDashArray;
                            break;
                        case "strokeDashoffset":
                            childViewModel.StrokeDashOffset = parentViewModel.StrokeDashOffset;
                            break;
                        case "strokeMiterlimit":
                            childViewModel.StrokeMiterlimit = parentViewModel.StrokeMiterlimit;
                            break;
                        case "fill":
                            childViewModel.Fill = parentViewModel.Fill;
                            break;
                        case "fillOpacity":
                            childViewModel.FillOpacity = parentViewModel.FillOpacity;
                            break;
                    }
                    ShapeViewModel.UpdateShape((Shape)child, childViewModel, str);
                }
            });

            parent.Children.Add((UIElement)child);
        }

        public override int GetChildCount(Canvas parent)
        {
            return parent.Children.Count;
        }

        public override DependencyObject GetChildAt(Canvas parent, int index)
        {
            return parent.Children[index];
        }

        public override void RemoveChildAt(Canvas parent, int index)
        {
            parent.Children.RemoveAt(index);
        }

        public override void RemoveAllChildren(Canvas parent)
        {
            parent.Children.Clear();
        }

        public override SVGShadowNode CreateShadowNodeInstance()
        {
            return new SVGShadowNode();
        }

        public override void SetDimensions(Canvas view, Dimensions dimensions)
        {

        }

        protected override Canvas CreateViewInstance(ThemedReactContext reactContext)
        {
            return new Canvas()
            {
                DataContext = new ShapeViewModel()
            };
        }
    }
}
