var express = require("express");
const { route } = require(".");
var router = express.Router();
var auth = require("../lib/auth.js");

router.get("/", function (request, response) {
  response.send(`${auth.Status(request, response)}`);
});
module.exports = router;
