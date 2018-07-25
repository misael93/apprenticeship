var moongose = require("mongoose");
Person = moongose.model('Persons');

exports.getall = (req , res) => {
    Person.find({}, (err , persons) => {
        if (err)
            res.send(err);
        res.json(persons);
    });
};

exports.create = (req , res) => {
    var newPerson = new Person(req.body);
    newPerson.save( (err, person) => {
        if (err)
            res.send(err);
        res.json(person);
    });
};

exports.show = (req, res) => {
    Person.findOne({ _id: req.params.id }, (err, person) => {
        if (err)
            res.send(err);
        res.json(person);
    });
}

exports.update = (req, res) => {
    Person.findOneAndUpdate({ _id: req.params.id },
        { name: req.params.name, age: req.params.age },
        { runValidators: true },
        (err, person) => {
        if (err)
            res.send(err);
        res.json(person);
    });
}

exports.delete = (req, res) => {
    Person.findOneAndDelete({ _id: req.params.id }, (err, person) => {
        if (err)
            res.send(err);
        res.json(person);
    });
}