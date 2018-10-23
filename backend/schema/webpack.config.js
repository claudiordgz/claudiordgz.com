const path = require('path')
const webpackTs = require('webpack-config-typescript')

let config = {
  mode: "production",
  entry: path.join(__dirname, 'src/buildSchema.ts'),
  target: 'node',
  output: {
    filename: 'build/buildSchema.js',
    libraryTarget: 'commonjs',
    path: path.join(__dirname)
  }
}

config = webpackTs.ts(config)

module.exports = config 
