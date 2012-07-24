var fs = require('fs');
var path = require('path');
var os = require('os');

var fn = require('./funcs.js');

var projectDir = '..';
var config = {
	buildOutputDir: projectDir + '\\output\\'
};


desc('This is the default task')
task('default', ['clean', 'compile'], function (params) {
	console.log('This is the default task');
	console.log(os.hostname);
});

desc('This is a test task for investigation')
task('test', [], function (params) {
	
});

desc('Cleans build artifacts')
task('clean', [], function (params) {
	console.log('clean');
	fn.rmDir(config.buildOutputDir);
});

desc('Compiles the project')
task('compile', ['clean','update'], function (params) {
	var cmd = 'C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\MSBuild c:\\projects\\poker\\poker.sln /property:OutDir=' + config.buildOutputDir;
	fn.exec(cmd);
});

desc('Updates nuget packages')
task('update', [], function (params) {
	var cmd = 'nuget.exe install c:\\projects\\poker\\packages\\packages.config -OutputDirectory c:\\projects\\poker\\packages\\';
	fn.exec(cmd);
});


