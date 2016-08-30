"use strict";

var path = require('path');
var WebpackNotifierPlugin = require('webpack-notifier');
var webpack = require("webpack");
module.exports = {
    context: path.join(__dirname, 'Content'),
    entry: {
        server: './server'
    },
    output: {
        path: path.join(__dirname, 'build'),
        filename: '[name].bundle.js'
    },
    module: {
        loaders: [
            // Transform JSX in .jsx files
            { test: /\.jsx$/, loader: 'jsx-loader?harmony'}
        ]
    },
    resolve: {
        // Allow require('./blah') to require blah.jsx
        extensions: ['', '.js', '.jsx']
    },
    externals: {
        //// Use external version of React (from CDN for client-side, or
        //// bundled with ReactJS.NET for server-side)
        react: "React"
    },
    plugins: [
      new WebpackNotifierPlugin(),
      new webpack.ProvidePlugin({
          $: 'jquery',
          jQuery: 'jquery',
          "window.jQuery": "jquery",
          React: "React",
          "window.react": "React",
          ReactDOM: "react-dom",
          "window.ReactDOM": "react-dom"
      })
    ]
};
