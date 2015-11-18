var fs = require('fs');
var path = require('path');
var express = require('express');
var bodyParser = require('body-parser');
var cors = require('cors');
var http = require('http');
var app = express();

var COMMENTS_FILE = path.join(__dirname, 'http://api.rottentomatoes.com/api/public/v1.0/lists/movies/upcoming.json?apikey=vymecugmgctsrxbbbmztpnb9');

app.set('port', (process.env.PORT || 3000));

app.use('/', express.static(path.join(__dirname, 'public')));
app.use(cors());
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended: true}));

app.get('http://api.rottentomatoes.com/api/public/v1.0/lists/movies/upcoming.json?apikey=vymecugmgctsrxbbbmztpnb9', function(req, res) {
  fs.readFile(COMMENTS_FILE, function(err, data) {
    if (err) {
      console.error(err);
      process.exit(1);
    }
    res.setHeader('Cache-Control', 'no-cache');
    res.setHeader("Access-Control-Allow-Origin", "http://localhost:3000");
    res.json(JSON.parse(data));
  });
});
app.listen(app.get('port'), function() {
  console.log('Server started: http://localhost:' + app.get('port') + '/');
});
