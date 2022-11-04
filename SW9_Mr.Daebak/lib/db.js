var mysql = require('mysql');
var db = mysql.createConnection({
    host     : 'localhost',
    user     : 'root',
    password : 'rhscnd12',
    database : 'SW9',
    port : "3306",
});
db.connect();
module.exports = db;

/*
CREATE TABLE customer(
    id int NOT NULL AUTO_INCREMENT,
    name varchar(20) NOT NULL,
    credit int NOT NULL,
    address varchar(30) NOT NULL,
    phone int NOT NULL,
    visit int DEFAULT 0,
    PRIMARY KEY ('id')
);

CREATE TABLE stock(
    ID INT NOT NULL,
    Name VARCHAR(30) NOT NULL,
    pwd INT NOT NULL,
    PRIMARY KEY(ID)
);*/