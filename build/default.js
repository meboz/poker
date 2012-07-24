var fs = require('fs');
var path = require('path');
var os = require('os');

var fn = require('./funcs.js');

var projectDir = '..';
var config = {
	buildOutputDir: projectDir + '\\output\\'
};

desc('This is a test task')
task('test', [], function (params) {
	
	var cmd = 'C:\\projects\\poker\\tools\\nunit\\nunit-console.exe C:\\projects\\poker\\output\\poker.tests.dll';
	fn.exec(cmd);
});

desc('Cleans build artifacts')
task('clean', [], function (params) {
	fn.rmDir('c:\\projects\\poker\\output\\');
});

desc('Compiles the project')
task('compile', [], function (params) {
	jake.Task['clean'].invoke();
	var cmd = 'C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\MSBuild c:\\projects\\poker\\poker.sln /property:OutDir=' + config.buildOutputDir;
	fn.exec(cmd);
});

desc('Updates nuget packages')
task('update', [], function (params) {
	var cmd = 'nuget.exe install c:\\projects\\poker\\packages\\packages.config -OutputDirectory c:\\projects\\poker\\packages\\';
	fn.exec(cmd);
});


