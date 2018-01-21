const jsdom = require("jsdom");
const $ = require("jquery")(new jsdom.JSDOM().window);
const generate = require("node-chartist");


module.exports = async function(callback, chartType, chartOptions, data) {
    try {
        const result = await generate(chartType, chartOptions, data);
        callback(null, result);
    } catch (error) {
        callback(error);
    }
};