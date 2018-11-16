using System;
using System.Collections.Generic;
using Autodesk.DesignScript.Geometry;
using Autodesk.DesignScript.Runtime;


namespace DynaShape.Goals
{
    [IsVisibleInDynamoLibrary(false)]
    public class OnLineSegmentGoal : Goal
    {
        public Triple TargetLineStart;
        public Triple TargetLineEnd;
        public Triple TargetSegmentVector;


        public OnLineSegmentGoal(List<Triple> nodeStartingPositions, Triple lineStart, Triple lineEnd, float weight = 1f)
        {
            TargetLineStart = lineStart;
            TargetLineEnd = lineEnd;
            TargetSegmentVector = TargetLineEnd - TargetLineStart;
            Weight = weight;
            StartingPositions = nodeStartingPositions.ToArray();
            Moves = new Triple[StartingPositions.Length];
            Weights = new float[StartingPositions.Length];
        }


        public OnLineSegmentGoal(List<Triple> nodeStartingPositions, Line line, float weight = 1f)
            : this(
                  nodeStartingPositions,
                  line.StartPoint.ToTriple(),
                  line.EndPoint.ToTriple(),
                  weight)
        {
        }


        public override void Compute(List<Node> allNodes)
        {
            for (int i = 0; i < NodeCount; i++)
            {
                var position = allNodes[NodeIndices[i]].Position;
                Triple v = TargetLineEnd - TargetLineStart;
                Triple u = TargetLineStart - position;
                var t = -1 * (v.Dot(u) / v.Dot(v));

                Triple q;
                if (t < 0)
                {
                    q = TargetLineStart - position;
                }
                else if (t >= 0 && t <= 1)
                {
                    var temp = (1 - t) * TargetLineStart + t * TargetLineEnd;
                    q = temp - position;
                }
                else
                {
                    q = TargetLineEnd - position;
                }

                Moves[i] = q;
                Weights[i] = Weight;
            }
        }
    }
}
