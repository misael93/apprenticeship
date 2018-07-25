var moongoose = require("mongoose");
var Schema = moongoose.Schema;

var PersonSchema = new Schema({
    name: {
        type: String,
        required: "Please enter name"
    },
    age: {
        type: Number,
        required: "Please enter age"
    }
});

module.exports = moongoose.model('Persons', PersonSchema);