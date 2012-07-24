var fs = require('fs');
var path = require('path');

var rmDir = function(dirPath) {
    try { var files = fs.readdirSync(dirPath); }
    catch(e) { return; }
    if (files.length > 0)
    for (var i = 0; i < files.length; i++) {
        var filePath = dirPath + '/' + files[i];
        if (fs.statSync(filePath).isFile())
        fs.unlinkSync(filePath);
        else
        rmDir(filePath);
    }
    fs.rmdirSync(dirPath);
};

var exec = function (cmd) {
	console.log(cmd);
	var spawn = require('child_process').spawn,
    cmd = spawn('cmd', ['/s', '/c', cmd]);

	cmd.stdout.on('data', function (data) {
		process.stdout.write(data);
	});

	cmd.stderr.on('data', function (data) {
		process.stderr.write(data);
	});

	cmd.on('exit', function (code) {
		console.log(code);
	});
}

module.exports.rmDir = rmDir;
module.exports.exec = exec;