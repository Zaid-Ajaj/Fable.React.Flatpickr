var path = require("path");
var webpack = require("webpack");


function resolve(filePath) {
  return path.join(__dirname, filePath)
}

var babelOptions = {
    presets: [
        ["@babel/preset-env", {
            "targets": "> 0.25%, not dead",
            "modules": false,
            // This adds polyfills when needed. Requires core-js dependency.
            // See https://babeljs.io/docs/en/babel-preset-env#usebuiltins
            "useBuiltIns": "usage",
        }]
    ],
}

var isProduction = process.argv.indexOf("-p") >= 0;
console.log("Bundling for " + (isProduction ? "production" : "development") + "...");

module.exports = {
  devtool: "source-map",
  entry: resolve('./app/App.fsproj'),
  output: {
    filename: 'bundle.js',
    path: resolve('./dist'),
  },
  resolve: {
    modules: [resolve("./node_modules/")]
  },
  devServer: {
    contentBase: resolve('./dist'),
    port: 8080
  },
  module: {
    rules: [
      {
        test: /\.fs(x|proj)?$/,
        use: {
          loader: "fable-loader",
          options: {
            babel: babelOptions,
            define: isProduction ? [] : ["DEBUG"]
          }
        }
      },
      {
        test: /\.js$/,
        exclude: /node_modules/,
        use: {
          loader: 'babel-loader',
          options: babelOptions
        },
      },
      {
        test: /\.(sa|c)ss$/,
        use: [
            "style-loader",
            "css-loader",
            "sass-loader"
        ]
      }
    ]
  },
  plugins: isProduction ? [] : [
    new webpack.HotModuleReplacementPlugin(),
    new webpack.NamedModulesPlugin()
  ]
};
