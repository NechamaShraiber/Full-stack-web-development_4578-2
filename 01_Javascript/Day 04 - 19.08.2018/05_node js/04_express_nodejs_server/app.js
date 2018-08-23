const path = require('path');
const fs = require('fs');
const express = require('express');

const app = express();

const viewBasicPath = path.join(__dirname + "/view");

fs.readdir(viewBasicPath, (err, files) => {
    files.forEach((file, index) => {
        app.use(express.static(viewBasicPath + "/" + file));
        app.get("/" + file, (req, res) => {
            res.sendFile(viewBasicPath + "/" + file + "/index.html");
        });
    })
});

const port = process.env.PORT || 3500;

app.listen(port, function () { console.log(`server listening on port ${port}`); });
