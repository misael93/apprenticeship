exports.Validator = (query) => {
    var obj = {success: true};
    if (isUndefined(query, "op")
        || isUndefined(query, "op1")
        || isUndefined(query, "op2")) {
        obj.success = false;
        obj.message = "Existe un error en el nombre de los parametros";
    } else if (!canParse(query["op"])
        || !canParse(query["op1"])
        || !canParse(query["op2"])) {
        obj.success = false;
        obj.message = "Existe un error en el valor de los parametros";
    }

    return obj;
}

function isUndefined(object, key) {
    return (object[key] != undefined) ? false : true;
}

function canParse(value) {
    return (Number.isNaN(parseInt(value))) ? false : true;
}