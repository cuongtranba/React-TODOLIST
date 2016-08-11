﻿using System.Web.Optimization;
using System.Web.Optimization.React;

namespace React_TODOLIST
{
    public static class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new BabelBundle("~/bundles/main").Include(
                "~/scripts/Todo.jsx"
            ));

            // Forces files to be combined and minified in debug mode
            // Only used here to demonstrate how combination/minification works
            // Normally you would use unminified versions in debug mode.
            //BundleTable.EnableOptimizations = true;
        }
    }
}