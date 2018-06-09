using System.Collections.Generic;
using Autodesk.DesignScript.Runtime;


namespace DynaShape.Goals
{
    [IsVisibleInDynamoLibrary(false)]
    public class AnchorGoal : Goal
    {
        public Triple Anchor;

        public AnchorGoal(Triple nodeStartingPosition, Triple anchor, float weight = 1000f)
        {
            Anchor = anchor;
            StartingPositions = new[] { nodeStartingPosition };
            Weight = weight;
            Moves = new Triple[1];
            Weights = new float[1];
        }

        public override string ToString()
        {
            return
                StartingPositions[0].X.ToString("00.00") + ", " +
                StartingPositions[0].Y.ToString("00.00") + ", " +
                StartingPositions[0].Z.ToString("00.00") + " | " +
                Anchor.X.ToString("00.00") + ", " +
                Anchor.Y.ToString("00.00") + ", " +
                Anchor.Z.ToString("00.00") + " | ";
        }

        public AnchorGoal(Triple nodeStartingPosition, float weight = 1000f)
            : this(nodeStartingPosition, nodeStartingPosition, weight)
        {
        }


        public override void Compute(List<Node> allNodes)
        {
            Moves[0] = Anchor - allNodes[NodeIndices[0]].Position;
            Weights[0] = Weight;
        }
    }
}
