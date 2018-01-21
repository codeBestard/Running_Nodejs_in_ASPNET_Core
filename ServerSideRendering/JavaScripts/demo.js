const jsdom = require("jsdom");
const $ = require("jquery")(new jsdom.JSDOM().window);
const generate = require("node-chartist");


module.exports = function(callback, chartType, chartOptions, data) {

    const chart = generate(chartType, chartOptions, data);
    chart.then(result => callback(null, result),
        error => callback(error));
};