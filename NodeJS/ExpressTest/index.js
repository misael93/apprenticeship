var express = require("express"),
    app = express(),
    port = 3000,
    mongoose = require("mongoose"),
    Person = require("./models/personModel"),
    bodyParser = require("body-parser");

mongoose.Promise = global.Promise;
mongoose.connect('mongodb://localhost/Personsdb');

app.use(bodyParser.urlencoded({extended: true}));
app.use(bodyParser.json());

var routes = require('./routes/routes');
routes(app);

app.listen(port);
