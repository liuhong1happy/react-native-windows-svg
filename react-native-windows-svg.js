import { PropTypes } from 'react';
import { requireNativeComponent, View } from 'react-native';

var svgFace = {
    name: 'SVGView',
    propTypes: {
        width: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        height: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        ...View.propTypes // include the default view properties
    },
    };

var shapeFace = {
    name: 'ShapeView',
    propTypes: {
        stroke: PropTypes.string,
        strokeWidth: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        strokeOpacity: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        //strokeLinecap: PropTypes.oneOf(['butt', 'square' , 'round']),
        //strokeLinejoin: PropTypes.oneOf(['miter', 'bevel', 'round']),
        strokeLinecap: PropTypes.string,
        strokeLinejoin: PropTypes.string,
        strokeDasharray: PropTypes.array,
        strokeMiterlimit: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        strokeDashoffset: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        fill: PropTypes.string,
        fillOpacity: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        origin: PropTypes.string,
        originX: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        originY: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        scale: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        rotate: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        opacity: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        x: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        y: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
    },
}

var rectFace = {
    name: 'RectView',
    propTypes: {
        rx: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        ry: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        width: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        height: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        ...shapeFace.propTypes,
        ...View.propTypes // include the default view properties
    },
}


var lineFace = {
    name: 'LineView',
    propTypes: {
        x1: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        y1: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        x2: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        y2: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        ...shapeFace.propTypes,
        ...View.propTypes // include the default view properties
    },
}

var circleFace = {
    name: 'CircleView',
    propTypes: {
        cx: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        cy: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        r: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        ...shapeFace.propTypes,
        ...View.propTypes // include the default view properties
    },
}

var ellipseFace = {
    name: 'EllipseView',
    propTypes: {
        cx: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        cy: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        rx: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        ry: PropTypes.oneOfType([PropTypes.number,PropTypes.string]),
        ...shapeFace.propTypes,
        ...View.propTypes // include the default view properties
    },
}

var pathFace = {
    name: 'PathView',
    propTypes: {
        d: PropTypes.string,
        ...shapeFace.propTypes,
        ...View.propTypes // include the default view properties
    },
}

var polylineFace = {
    name: 'PolylineView',
    propTypes: {
        points: PropTypes.string,
        fillRule: PropTypes.oneOf(['evenodd', 'nonzero']),
        ...shapeFace.propTypes,
        ...View.propTypes // include the default view properties
    }
}

var polygonFace = {
    name: 'PolygonView',
    propTypes: {
        points: PropTypes.string,
        fillRule: PropTypes.oneOf(['evenodd', 'nonzero']),
        ...shapeFace.propTypes,
        ...View.propTypes // include the default view properties
    }
}

var groupFace = {
    name: 'GroupView',
    propTypes: {
        ...shapeFace.propTypes,
        ...View.propTypes // include the default view properties
    }
}

const Svg = requireNativeComponent('RCTSVGView', rectFace);
const Rect = requireNativeComponent('RCTRectView', rectFace);
const Line = requireNativeComponent('RCTLineView', lineFace);
const Circle = requireNativeComponent('RCTCircleView', circleFace);
const Ellipse = requireNativeComponent('RCTEllipseView', ellipseFace);
const Polyline = requireNativeComponent('RCTPolylineView', polylineFace);
const Polygon = requireNativeComponent('RCTPolygonView', polygonFace);
const Path = requireNativeComponent('RCTPathView', pathFace);
const G = requireNativeComponent('RCTGroupView', groupFace);

export { 
    Svg,
    Rect,
    Line,
    Circle,
    Ellipse,
    Polyline,
    Polygon,
    Path,
    G  
}

export default Svg