"use strict";

var path = require('path');
var WebpackNotifierPlugin = require('webpack-notifier');

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
          { test: /\.jsx$/, loader: 'jsx-loader?harmony' }
        ],
    },
    resolve: {
        // Allow require('./blah') to require blah.jsx
        extensions: ['', '.js', '.jsx']
    },
    externals: {
        // Use external version of React (from CDN for client-side, or
        // bundled with ReactJS.NET for server-side)
        react: 'React'
    },
    plugins: [
      new WebpackNotifierPlugin()
    ]
};
