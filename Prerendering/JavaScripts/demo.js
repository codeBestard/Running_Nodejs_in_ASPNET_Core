const jsdom     = require("jsdom");
const $         = require("jquery")(new jsdom.JSDOM().window);
const prerender = require("aspnet-prerendering");

module.exports = prerender.createServerRenderer(

    async function ({ data: { prefix } } ) {

        return await new Promise(function (resolve, reject) {

            let elem = $("<h1>");
            elem.html( ` ${prefix} ${new Date().toLocaleTimeString("en-Us")}` );

            let result = elem[0].outerHTML;
            resolve({ html: result });
        });
    }
);