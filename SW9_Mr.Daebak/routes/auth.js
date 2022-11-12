var express = require("express");
var router = express.Router();
var path = require("path");
var db = require("../lib/db.js");
router.get("/login", function (req, res) {
  console.log("entered login page");
  let tmp_html = `
        <form action="/auth/login_process" method="post">
            <p><input type="text" name="id" placeholder="id"></p>
            <p><input type="pasword" name="password" placeholder="password"></p>
            <p>
                <input type="submit" value="login">
            </p>
        </form>
    `;
  res.send(tmp_html);
});

router.post("/login/process", function (request, response) {
  //implement Login function
  console.log("entered login process");
  var post = request.body;
  var id = post.id;
  var password = post.password;
  console.log("now entered id ", id, " and password is : ", password);
  //(+)id,password sanitize?
  db.query(
    `SELECT ifnull(max(name),0) name FROM AUTH WHERE id=? AND password=?`,
    [id, password],
    function (err, name) {
      if (name) {
        //login success
        request.session.is_logined = true;
        request.session.name = name;
        request.session.save(function () {
          if (name == "admin") response.redirect(`/manage`);
          else response.redirect(`/order`);
        });
      } else {
        //null.. login failed
        response.send("Log In Fail..");
        //팝업띄우거나 뭐.. 나중에 처리
      }
    }
  );
});

router.get("/logout", function (request, response) {
  request.session.destroy(function (err) {
    response.redirect(`/`);
  });
});
module.exports = router;
