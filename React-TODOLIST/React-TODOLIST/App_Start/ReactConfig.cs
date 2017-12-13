using React;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(React_TODOLIST.ReactConfig), "Configure")]

namespace React_TODOLIST
{
    public static class ReactConfig
    {
        public static void Configure()
        {
            // If you want to use server-side rendering of React components, 
            // add all the necessary JavaScript files here. This includes 
            // your components as well as all of their dependencies.
            // See http://reactjs.net/ for more information. Example:
            //ReactSiteConfiguration.Configuration.SetLoadBabel(false).AddScriptWithoutTransform("~/build/vendor.bundle.js");
            //ReactSiteConfiguration.Configuration.SetLoadBabel(false).AddScriptWithoutTransform("~/build/server.bundle.js");
            // If you use an external build too (for example, Babel, Webpack,
            // Browserify or Gulp), you can improve performance by disabling 
            // ReactJS.NET's version of Babel and loading the pre-transpiled 
            // scripts. Example:
            //ReactSiteConfiguration.Configuration
            //	.SetLoadBabel(false)
            //	.AddScriptWithoutTransform("~/Scripts/bundle.server.js")
        }
    }
}