/// <binding AfterBuild='default' Clean='clean' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var del = require('del');
var browserify = require('gulp-browserify');

var paths = {
    scripts: ['scripts/**/*.js', 'scripts/**/*.ts', 'scripts/**/*.map'],
    libs: [
        'node_modules/jquery/dist/jquery.js',
        'node_modules/bootstrap/dist/css/bootstrap.css',
        'node_modules/bootstrap/dist/css/bootstrap.css.map',
        'node_modules/bootstrap/dist/js/bootstrap.js',
        'node_modules/bootstrap/dist/js/bootstrap.js.map',
        'node_modules/popper.js/dist/popper.js',
        'node_modules/popper.js/dist/popper.js.map'
    ]
};

gulp.task('lib', function () {
    gulp.src(paths.libs)
        .pipe(browserify({
            insertGlobals: false,
            debug: false
        }).pipe(gulp.dest('wwwroot/scripts/lib')));
});

gulp.task('clean', function () {
    return del(['wwwroot/scripts/**/*']);
});

gulp.task('default', ['lib'], function () {
    gulp.src(paths.scripts).pipe(gulp.dest('wwwroot/scripts'));
});