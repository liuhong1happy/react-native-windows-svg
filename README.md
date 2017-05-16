# react-native-windows-svg

create windows svg component with Canvas、Shape.

## Install

    npm install --save react-native-windows-svg
    # Add the `node_modules/react-native-windows-svg/windows/ReactNativeSVG` project to your `Solution`.
  
## Usage
    
1. Add the SVGReactPackage in your `Solution`.

```c#
        /// <summary>
        /// MainPage.cs
        /// </summary>
        ...
        public override List<IReactPackage> Packages
        {
            get
            {
                return new List<IReactPackage>
                {
                    new MainReactPackage(),
                    new SVGReactPackage() // add this line
                };
            }
        }
        ...
```

2. Use the component in your react-native project.
```js
    ...
    import {Svg, Rect } from 'react-native-windows-svg';
    ...
      <Svg width={300} height={300} >
        <Rect stroke="#000000" fill="#ffffff" rx={10} ry={10} strokeWidth={1} />
      </Svg>
    ...
```
## Todos

- [x] SVG
- [x] Rect
- [ ] Text
- [x] Circle
- [x] Line
- [x] Ellipse
- [x] G
- [x] Path
- [x] Polygon
- [x] Polyline

## Contact
- Email: [liuhong1.happy@163.com](mailto:liuhong1.happy@163.com)
