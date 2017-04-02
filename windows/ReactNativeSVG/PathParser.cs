using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.Foundation;

namespace ReactNativeSVG
{
    class PathParser
    {
        private Regex PATH_REG_EXP = new Regex("[a-df-z]|[\\-+]?(?:[\\d.]e[\\-+]?|[^\\s\\-+,a-z])+", RegexOptions.IgnoreCase);
        private Regex DECIMAL_REG_EXP = new Regex("(\\.\\d+)(?=\\-?\\.)");
        private string mString;
        private double mScale;
        private PathGeometry mPath;
        private PathFigure mFigure;
        private bool mValid = true;
        private Match mMatcher;
        private string mLastValue;
        private string mLastCommand;

        private double mPenX = 0f;
        private double mPenY = 0f;
        private double mPenDownX;
        private double mPenDownY;
        private double mPivotX = 0f;
        private double mPivotY = 0f;
        private bool mPendDownSet = false;
        public PathParser(string d, double scale = 1)
        {
            mString = d;
            mScale = 1;
        }

        public PathGeometry getPath()
        {
            mPath = new PathGeometry();
            mPath.Figures = new PathFigureCollection();
            mMatcher = PATH_REG_EXP.Match(DECIMAL_REG_EXP.Replace(mString, "$1,"));
            while (mMatcher.Success && mValid)
            {
                ExecuteCommand(mMatcher.Value);
                mMatcher = mMatcher.NextMatch();
            }
            return mPath;
        }

        private double getNextdouble()
        {
            if (mLastValue!= "" && mLastValue != null)
            {
                String lastValue = mLastValue;
                mLastValue = null;
                return Convert.ToDouble(lastValue);
            }
            else if (mMatcher.Success)
            {
                mMatcher = mMatcher.NextMatch();
                return Convert.ToDouble(mMatcher.Value);
            }
            else
            {
                mValid = false;
                mPath = new PathGeometry();
                return 0;
            }
        }

        private bool getNextbool()
        {
            if (mMatcher.Success)
            {
                mMatcher = mMatcher.NextMatch();
                return mMatcher.Value == "1";
            }
            else
            {
                mValid = false;
                mPath = new PathGeometry();                
                return false;
            }
        }

        private void ExecuteCommand(string command)
        {
            switch (command)
            {
                // moveTo command
                case "m":
                    MoveCommand(getNextdouble(), getNextdouble());
                    break;
                case "M":
                    MoveToCommand(getNextdouble(), getNextdouble());
                    break;

                // lineTo command
                case "l":
                    LineCommand(getNextdouble(), getNextdouble());
                    break;
                case "L":
                    LineToCommand(getNextdouble(), getNextdouble());
                    break;

                // horizontalTo command
                case "h":
                    LineCommand(getNextdouble(), 0);
                    break;
                case "H":
                    LineToCommand(getNextdouble(), mPenY);
                    break;

                // verticalTo command
                case "v":
                    LineCommand(0, getNextdouble());
                    break;
                case "V":
                    LineToCommand(mPenX, getNextdouble());
                    break;

                // curveTo command
                case "c":
                    CurveCommand(getNextdouble(), getNextdouble(), getNextdouble(), getNextdouble(), getNextdouble(), getNextdouble());
                    break;
                case "C":
                    CurveToCommand(getNextdouble(), getNextdouble(), getNextdouble(), getNextdouble(), getNextdouble(), getNextdouble());
                    break;

                // smoothCurveTo command
                case "s":
                    SmoothCurveCommand(getNextdouble(), getNextdouble(), getNextdouble(), getNextdouble());
                    break;
                case "S":
                    SmoothCurveToCommand(getNextdouble(), getNextdouble(), getNextdouble(), getNextdouble());
                    break;

                // quadraticBezierCurveTo command
                case "q":
                    QuadraticBezierCurveCommand(getNextdouble(), getNextdouble(), getNextdouble(), getNextdouble());
                    break;
                case "Q":
                    QuadraticBezierCurveToCommand(getNextdouble(), getNextdouble(), getNextdouble(), getNextdouble());
                    break;

                // smoothQuadraticBezierCurveTo command
                case "t":
                    SmoothQuadraticBezierCurveCommand(getNextdouble(), getNextdouble());
                    break;
                case "T":
                    SmoothQuadraticBezierCurveToCommand(getNextdouble(), getNextdouble());
                    break;

                // arcTo command
                case "a":
                    ArcCommand(getNextdouble(), getNextdouble(), getNextdouble(), getNextbool(), getNextbool(), getNextdouble(), getNextdouble());
                    break;
                case "A":
                    ArcToCommand(getNextdouble(), getNextdouble(), getNextdouble(), getNextbool(), getNextbool(), getNextdouble(), getNextdouble());
                    break;
                // close command
                case "Z":
                case "z":
                    CloseCommand();
                    break;
                default:
                    mLastValue = command;
                    ExecuteCommand(mLastCommand);
                    return;
            }

            mLastCommand = command;

            if (command == "m")
            {
                mLastCommand = "l";
            }
            else if (command == "M")
            {
                mLastCommand = "L";
            }
        }

        private void MoveCommand(double x, double y)
        {
            MoveToCommand(x + mPenX, y + mPenY);
        }

        private void MoveToCommand(double x, double y)
        {
            mPivotX = mPenX = x;
            mPivotY = mPenY = y;

            mFigure = new PathFigure();
            mPath.Figures.Add(mFigure);
            mFigure.StartPoint = new Point(x * mScale, y * mScale);
            mFigure.Segments = new PathSegmentCollection();
        }

        private void LineCommand(double x, double y)
        {
            LineToCommand(x + mPenX, y + mPenY);
        }

        private void LineToCommand(double x, double y)
        {
            setPenDown();
            mPivotX = mPenX = x;
            mPivotY = mPenY = y;
            mFigure.Segments.Add(new LineSegment() { Point = new Point(x * mScale, y * mScale) });
        }

        private void CurveCommand(double c1x, double c1y, double c2x, double c2y, double ex, double ey)
        {
            CurveToCommand(c1x + mPenX, c1y + mPenY, c2x + mPenX, c2y + mPenY, ex + mPenX, ey + mPenY);
        }

        private void CurveToCommand(double c1x, double c1y, double c2x, double c2y, double ex, double ey)
        {
            setPenDown();
            mPivotX = c2x;
            mPivotY = c2y;
            mPenX = ex;
            mPenY = ey;
            mFigure.Segments.Add(new BezierSegment() {
                Point1 = new Point(c1x * mScale, c1y * mScale),
                Point2 = new Point(c2x * mScale, c2y * mScale),
                Point3 = new Point(ex * mScale, ey * mScale),
            });
        }

        private void SmoothCurveCommand(double c1x, double c1y, double ex, double ey)
        {
            SmoothCurveToCommand(c1x + mPenX, c1y + mPenY, ex + mPenX, ey + mPenY);
        }

        private void SmoothCurveToCommand(double c1x, double c1y, double ex, double ey)
        {
            setPenDown();
            double c2x = c1x;
            double c2y = c1y;
            c1x = (mPenX * 2) - mPivotX;
            c1y = (mPenY * 2) - mPivotY;
            mPivotX = c2x;
            mPivotY = c2y;
            mPenX = ex;
            mPenY = ey;
            mFigure.Segments.Add(new BezierSegment()
            {
                Point1 = new Point(c1x * mScale, c1y * mScale),
                Point2 = new Point(c2x * mScale, c2y * mScale),
                Point3 = new Point(ex * mScale, ey * mScale),
            });
        }

        private void QuadraticBezierCurveCommand(double c1x, double c1y, double c2x, double c2y)
        {
            QuadraticBezierCurveToCommand(c1x + mPenX, c1y + mPenY, c2x + mPenX, c2y + mPenY);
        }

        private void QuadraticBezierCurveToCommand(double c1x, double c1y, double c2x, double c2y)
        {
            setPenDown();
            mPivotX = c1x;
            mPivotY = c1y;
            double ex = c2x;
            double ey = c2y;
            c2x = (ex + c1x * 2) / 3;
            c2y = (ey + c1y * 2) / 3;
            c1x = (mPenX + c1x * 2) / 3;
            c1y = (mPenY + c1y * 2) / 3;
            mPenX = ex;
            mPenY = ey;
            mFigure.Segments.Add(new BezierSegment()
            {
                Point1 = new Point(c1x * mScale, c1y * mScale),
                Point2 = new Point(c2x * mScale, c2y * mScale),
                Point3 = new Point(ex * mScale, ey * mScale),
            });
        }

        private void SmoothQuadraticBezierCurveCommand(double c1x, double c1y)
        {
            SmoothQuadraticBezierCurveToCommand(c1x + mPenX, c1y + mPenY);
        }

        private void SmoothQuadraticBezierCurveToCommand(double c1x, double c1y)
        {
            double c2x = c1x;
            double c2y = c1y;
            c1x = (mPenX * 2) - mPivotX;
            c1y = (mPenY * 2) - mPivotY;
            QuadraticBezierCurveToCommand(c1x, c1y, c2x, c2y);
        }

        private void ArcCommand(double rx, double ry, double rotation, bool outer, bool clockwise, double x, double y)
        {
            ArcToCommand(rx, ry, rotation, outer, clockwise, x + mPenX, y + mPenY);
        }

        private void ArcToCommand(double rx, double ry, double rotation, bool outer, bool clockwise, double x, double y)
        {
            double tX = mPenX;
            double tY = mPenY;

            ry = Math.Abs(ry == 0 ? (rx == 0 ? (y - tY) : rx) : ry);
            rx = Math.Abs(rx == 0 ? (x - tX) : rx);

            if (rx == 0 || ry == 0 || (x == tX && y == tY))
            {
                LineToCommand(x, y);
                return;
            }

            double rad = (double)(Math.PI * rotation / 180);
            double cos = (double)Math.Cos(rad);
            double sin = (double)Math.Sin(rad);
            x -= tX;
            y -= tY;

            // Ellipse Center
            double cx = cos * x / 2 + sin * y / 2;
            double cy = -sin * x / 2 + cos * y / 2;
            double rxry = rx * rx * ry * ry;
            double rycx = ry * ry * cx * cx;
            double rxcy = rx * rx * cy * cy;
            double a = rxry - rxcy - rycx;

            if (a < 0)
            {
                a = (double)Math.Sqrt(1 - a / rxry);
                rx *= a;
                ry *= a;
                cx = x / 2;
                cy = y / 2;
            }
            else
            {
                a = (double)Math.Sqrt(a / (rxcy + rycx));

                if (outer == clockwise)
                {
                    a = -a;
                }
                double cxd = -a * cy * rx / ry;
                double cyd = a * cx * ry / rx;
                cx = cos * cxd - sin * cyd + x / 2;
                cy = sin * cxd + cos * cyd + y / 2;
            }

            // Rotation + Scale Transform
            double xx = cos / rx;
            double yx = sin / rx;
            double xy = -sin / ry;
            double yy = cos / ry;

            // Start and End Angle
            double sa = (double)Math.Atan2(xy * -cx + yy * -cy, xx * -cx + yx * -cy);
            double ea = (double)Math.Atan2(xy * (x - cx) + yy * (y - cy), xx * (x - cx) + yx * (y - cy));

            cx += tX;
            cy += tY;
            x += tX;
            y += tY;

            setPenDown();

            mPenX = mPivotX = x;
            mPenY = mPivotY = y;

            if (rx != ry || rad != 0f)
            {
                arcToBezier(cx, cy, rx, ry, sa, ea, clockwise, rad);
            }
            else
            {

                double start = (double)(sa*180 / Math.PI);
                double end = (double)(ea*180 / Math.PI);
                double sweep = Math.Abs((start - end) % 360);

                if (outer)
                {
                    if (sweep < 180)
                    {
                        sweep = 360 - sweep;
                    }
                }
                else
                {
                    if (sweep > 180)
                    {
                        sweep = 360 - sweep;
                    }
                }

                if (!clockwise)
                {
                    sweep = -sweep;
                }


                mFigure.Segments.Add(new ArcSegment()
                {
                    Point = new Point((cx - rx) * mScale, (cy - rx) * mScale),
                    Size = new Size((cx + rx) * mScale, (cy + rx) * mScale),
                    RotationAngle = sweep,
                    SweepDirection = clockwise ? SweepDirection.Clockwise : SweepDirection.Counterclockwise,
                    IsLargeArc = outer
                });
            }
        }
        private void CloseCommand()
        {
            if (mPendDownSet)
            {
                mPenX = mPenDownX;
                mPenY = mPenDownY;
                mPendDownSet = false;
                mFigure.IsClosed = true;
            }
        }

        private void arcToBezier(double cx, double cy, double rx, double ry, double sa, double ea, bool clockwise, double rad)
        {
            // Inverse Rotation + Scale Transform
            double cos = (double)Math.Cos(rad);
            double sin = (double)Math.Sin(rad);
            double xx = cos * rx;
            double yx = -sin * ry;
            double xy = sin * rx;
            double yy = cos * ry;

            // Bezier Curve Approximation
            double arc = ea - sa;
            if (arc < 0 && clockwise)
            {
                arc += Math.PI * 2;
            }
            else if (arc > 0 && !clockwise)
            {
                arc -= Math.PI * 2;
            }

            int n = (int)Math.Ceiling(Math.Abs(arc / (Math.PI / 2)));

            double step = arc / n;
            double k = (4 / 3) * (double)Math.Tan(step / 4);

            double x = (double)Math.Cos(sa);
            double y = (double)Math.Sin(sa);

            for (int i = 0; i < n; i++)
            {
                double cp1x = x - k * y;
                double cp1y = y + k * x;

                sa += step;
                x = (double)Math.Cos(sa);
                y = (double)Math.Sin(sa);

                double cp2x = x + k * y;
                double cp2y = y - k * x;

                CurveToCommand(
                        (cx + xx * cp1x + yx * cp1y) * mScale,
                        (cy + xy * cp1x + yy * cp1y) * mScale,
                        (cx + xx * cp2x + yx * cp2y) * mScale,
                        (cy + xy * cp2x + yy * cp2y) * mScale,
                        (cx + xx * x + yx * y) * mScale,
                        (cy + xy * x + yy * y) * mScale
                    );
            }
        }

        private void setPenDown()
        {
            if (!mPendDownSet)
            {
                mPenDownX = mPenX;
                mPenDownY = mPenY;
                mPendDownSet = true;
            }
        }
    }
}
