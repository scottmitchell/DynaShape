using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Configuration;
using System.Threading;
using System.Windows.Controls;
using Autodesk.DesignScript.Runtime;
using Dynamo.Controls;
using Dynamo.Wpf.ViewModels.Watch3D;
using DynaShape;
using DynaShape.Goals;
using DynaShape.GeometryBinders;


namespace DynaShape.ZeroTouch
{
    public static class Solver
    {
        /// <summary>
        /// Execute the solver silently and only display the final result.
        /// </summary>
        /// <param name="solver">The solver, which can be obtained from the Solver.Create node</param>
        /// <param name="goals">The goals/constraints that the solver will solve</param>
        /// <param name="geometryBinders">The geometry binders</param>
        /// <param name="iterations">The maximum number of iterations that will be excuted</param>
        /// <param name="threshold">if the nodes's movement is below this threshold, the solver will stop executing and output the result</param>
        /// <param name="execute">This allows us to temporarily disable the solver while setting up/chaging the parameters the parameters</param>
        /// <param name="enableMomentum">Apply momentum effect to the movement of the nodes. For simulation of physical motion, this results in more realistic motion. For constraint-based optimization, it often helps the solver to reach the final solution in fewer iteration (i.e. faster), but can sometimes lead to unstable and counter-intuitive solution. In such case, try setting momnentum to False </param>
        /// <returns></returns>
        [MultiReturn("nodePositions", "goalOutputs", "geometries", "stats")]
        [CanUpdatePeriodically(true)]
        public static Dictionary<string, object> ExecuteSilently(
           List<Goal> goals,
           [DefaultArgument("null")] List<GeometryBinder> geometryBinders,
           [DefaultArgument("10000")] int iterations,
           [DefaultArgument("0.001")] double threshold,
           [DefaultArgument("true")] bool execute,
           [DefaultArgument("true")] bool enableMomentum)
        {
            if (!execute)
                return new Dictionary<string, object> {
                    { "nodePositions", null },
                    { "goalOutputs", null },
                    { "geometries", null },
                    { "stats", null}};

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            DynaShape.Solver solver = new DynaShape.Solver();
            solver.AddGoals(goals);
            if (geometryBinders != null) solver.AddGeometryBinders(geometryBinders);
            solver.EnableMomentum = enableMomentum;
            solver.Execute(iterations, threshold);

            TimeSpan computationTime = stopwatch.Elapsed;
            stopwatch.Restart();

            return new Dictionary<string, object> {
                { "nodePositions", solver.GetNodePositionsAsPoints() },
                { "goalOutputs", solver.GetGoalOutputs() },
                { "geometries", solver.GetGeometries() },
                { "stats", String.Concat(
                    "Computation Time: " + computationTime,
                    "\nData Output Time: " + stopwatch.Elapsed,
                    "\nIterations      : " + solver.CurrentIteration,
                    "\nMovement        : " + solver.GetKineticEnergy())}};
        }
    }
}

