var http = require("http");
var url = require("url");
var validator = require("./validator");
var addition = require("./addition");
var substraction = require("./substraction");
var multiplication = require("./multiplication");
var division = require("./division");

http.createServer((req, res) => {

    var q = url.parse(req.url, true).query;
    var responseText = "";
    
    var v = validator.Validator(q);

    if (v.success) {
        switch (q.op) {
            case "1": responseText = "Suma = " + addition.Addition(q.op1, q.op2);
                break;
            case "2": responseText = "Resta = " + substraction.Substraction(q.op1, q.op2);
                break;
            case "3": responseText = "Multiplicacion = " + multiplication.Multiplication(q.op1, q.op2);
                break;
            case "4": responseText = "Division = " + division.Division(q.op1, q.op2);
                break;
            default: responseText = "Ingrese una operacion valida (1-4)";
        }
    } else {
        responseText = v.message;
    }

    res.writeHead(200, {ContentType: "text/html"});
    res.end(responseText);
}).listen(8000);