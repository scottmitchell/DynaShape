using System.Collections.Generic;
using DSCore;
using Autodesk.DesignScript.Geometry;
using Autodesk.DesignScript.Runtime;
using DynaShape.GeometryBinders;
using HelixToolkit.Wpf.SharpDX.Core;
using Point = Autodesk.DesignScript.Geometry.Point;


namespace DynaShape.ZeroTouch
{
    /// <summary>
    /// 
    /// </summary>
    public static class GeometryBinders
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static LineBinder LineBinder(
            Line line,
            [DefaultArgument("null")] Color color)
        {
            return new LineBinder(
                line.StartPoint.ToTriple(),
                line.EndPoint.ToTriple(),
                color?.ToSharpDXColor() ?? DynaShapeDisplay.DefaultLineColor);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static LineBinder LineBinder(
            Point startPoint,
            Point endPoint,
            [DefaultArgument("null")] Color color)
        {
            return new LineBinder(
                startPoint.ToTriple(),
                endPoint.ToTriple(),
                color?.ToSharpDXColor() ?? DynaShapeDisplay.DefaultLineColor);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="color"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        public static PolylineBinder PolylineBinder(
            List<Point> vertices,
            [DefaultArgument("null")] Color color,
            [DefaultArgument("false")] bool loop)
        {
            return new PolylineBinder(
                vertices.ToTriples(),
                color?.ToSharpDXColor() ?? DynaShapeDisplay.DefaultLineColor,
                loop);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="mesh"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static MeshBinder MeshBinder(
            Autodesk.DesignScript.Geometry.Mesh mesh,
            [DefaultArgument("null")] Color color)
        {
            return new MeshBinder(
                mesh,
                color?.ToSharpDXColor() ?? DynaShapeDisplay.DefaultMeshFaceColor);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="toolkitMesh"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static MeshBinder MeshBinder(
            Autodesk.Dynamo.MeshToolkit.Mesh toolkitMesh,
            [DefaultArgument("null")] Color color)
        {
            return new MeshBinder(
                toolkitMesh,
                color?.ToSharpDXColor() ?? DynaShapeDisplay.DefaultMeshFaceColor);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="toolkitMesh"></param>
        /// <param name="color"></param>
        /// <param name="textureFileName"></param>
        /// <param name="textureCoordinates"></param>
        /// <returns></returns>
        public static TexturedMeshBinder TexturedMeshBinder(
            Autodesk.Dynamo.MeshToolkit.Mesh toolkitMesh,
            [DefaultArgument("null")] Color color,
            string textureFileName,
            TextureCoordinateSet textureCoordinates)
        {
            return new TexturedMeshBinder(
                toolkitMesh,
                color?.ToSharpDXColor() ?? DynaShapeDisplay.DefaultMeshFaceColor,
                textureFileName,
                textureCoordinates.Content);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="geometryBinder"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static GeometryBinder ChangeColor(GeometryBinder geometryBinder, Color color)
        {
            geometryBinder.Color = color.ToSharpDXColor();
            return geometryBinder;
        }
    }
}