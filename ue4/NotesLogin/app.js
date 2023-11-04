const express = require('express')
const bodyParser = require('body-parser');
const { v4: uuidv4 } = require('uuid');

const port = 3000
const app = express()

app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());
tokens = new Map();

app.post('/login', function (req, res) {
    var username = req.body.username;
    var password = req.body.password;
    var token = uuidv4();

    if (username == 'docker' && password == '12345') {
        tokens.set(token, username);
        res.send(token);
    } else {
        res.status(401).send('Forbidden')
    }
});

app.post('/verify', function (req, res) {
    if (tokens.has(req.body.token)) {
        res.send('Success');
    } else {
        res.status(401).send('Error');
    }
});

app.listen(port, () => console.log(`NotesLogin started at port ${port}!`))
