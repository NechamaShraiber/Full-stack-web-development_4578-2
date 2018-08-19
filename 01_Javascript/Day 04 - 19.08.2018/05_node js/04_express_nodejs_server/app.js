const path = require('path');
const fs = require('fs');
const express = require('express');

const app = express();

const viewBasicPath = path.join(__dirname + "/view");

fs.readdir(viewBasicPath, function (err, files) {
    if (err) {
        console.error("Could not list the directory.", err);
    }

    files.forEach(function (file, index) {
        app.use(express.static(viewBasicPath + "/" + file));
        app.get("/app" + index, (req, res) => {
            res.sendFile(viewBasicPath + "/" + file + "/index.html");
        });
    })
}
);

const port = process.env.PORT || 3500;

app.listen(port, function () { console.log(`server listening on port ${port}`); });
