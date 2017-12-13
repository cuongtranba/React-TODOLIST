"use strict";
var node_dir = __dirname + '/node_modules';
var path = require('path');
var WebpackNotifierPlugin = require('webpack-notifier');
var webpack = require("webpack");
module.exports = {
    context: path.join(__dirname, 'Content'),
    entry: {
        server: './server',
        vendor: ["jquery", "react", "react-dom", "bootstrap", "bootstrap-validator"]
    },
    output: {
        path: path.join(__dirname, 'build'),
        filename: '[name].bundle.js'
    },
    watch: true,
    module: {
        loaders: [
            // Transform JSX in .jsx files
            { test: /\.jsx$/, loader: 'jsx-loader?harmony' },
            { test: require.resolve("jquery"), loader: "expose?$!expose?jQuery" }
        ]
    },
    resolve: {
        // Allow require('./blah') to require blah.jsx
        extensions: ['', '.js', '.jsx'],
        //alias: {
        //    'jquery': node_dir + '/jquery/dist/jquery.js'
        //}
    },
    externals: {
        ////// Use external version of React (from CDN for client-side, or
        ////// bundled with ReactJS.NET for server-side)
        //react: "React"
    },
    plugins: [
      new WebpackNotifierPlugin(),
      new webpack.ProvidePlugin({
          $: "jquery", 
          jQuery: "jquery", 
          "window.jQuery": "jquery",
          React: "react",
          ReactDOM:"react-dom"
      }),
      new webpack.optimize.CommonsChunkPlugin(/* chunkName= */"vendor", /* filename= */"vendor.bundle.js"),
      //new webpack.optimize.UglifyJsPlugin({
      //    compress: {
      //        warnings: false
      //    }
      //})
    ]
};
