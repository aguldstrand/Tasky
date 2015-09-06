module.exports = {
    entry: "./client/main.js",
    output: {
        path: "./wwwroot/assets",
        filename: "bundle.js"
    },
    module: {
        loaders: [{
            test: /\.css$/,
            exclude: /\.useable\.css$/,
            loader: "style!css"
        }, {
            test: /\.useable\.css$/,
            loader: "style/useable!css"
        }, {
            test: /\.css$/,
            loaders: 'style!css'
        }, {
            test: /\.css$/,
            loaders: 'style!css'
        }, {
            test: /\.scss$/,
            loader: 'style!css!sass'
        }]
    }
};