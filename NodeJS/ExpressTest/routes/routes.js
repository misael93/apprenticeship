module.exports = function(app){
    var controller = require("../controllers/personController");

    app.route('/persons')
        .get(controller.getall)
        .post(controller.create);

    app.route('/persons/:id')
        .get(controller.show)
        .put(controller.update)
        .delete(controller.delete);
}