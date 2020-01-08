// # Globbing
// for performance reasons we're only matching one level down:
// 'test/spec/{,*/}*.js'
// use this if you want to recursively match all subfolders:
// 'test/spec/**/*.js'
module.exports = function (grunt) {

    var currentProjectName = "App";

    grunt.file.defaultEncoding = 'utf8';

    grunt.file.preserveBOM = true;

    this.defaultEncoding = grunt.file.defaultEncoding;

    // Load grunt tasks automatically
    require('load-grunt-tasks')(grunt);

    // Time how long tasks take. Can help when optimizing build times
    require('time-grunt')(grunt);

    var modRewrite = require('connect-modrewrite')(['!\.html|\.js|\.jpg|\.mp4|\.mp3|\.gif|\.svg\|\.less\|\.woff2\|.css|\.png$ /index.html [L]']);

    // Configurable paths for the application
    var appConfig = {
        app: require('./bower.json').appPath || 'app',
        dist: 'dist',
        ngconstant:
        {
            filePath: "/scripts/app.config.js"
        }
    };

    var liverelioadMiddleware = function (connect, options) {
        var middlewares = [];
        middlewares.push(modRewrite);
        middlewares.push(serveStatic('.tmp'));

        middlewares.push(connect().use(
          '/bower_extras',
          serveStatic('./bower_extras')
        ));

        middlewares.push(connect().use(
          '/app/styles',
          serveStatic('./app/styles')
        ));

        middlewares.push(connect().use(
          '/scripts',
          serveStatic('./scripts')
        ));

        middlewares.push(connect().use(
          '/bower_components',
          serveStatic('./bower_components')
        ));

        middlewares.push(connect().use(
          '/fonts',
          serveStatic('./bower_components/bootstrap/dist/fonts')
        ));

        middlewares.push(connect().use(
          '/fonts',
          serveStatic('./bower_components/material-design-icons-iconfont/dist/fonts')
        ));

        middlewares.push(serveStatic(appConfig.app));
        options.base.forEach(function (base) {
            middlewares.push(serveStatic(base));
        });
        return middlewares;
    };

    grunt.loadNpmTasks('grunt-jsdoc');

    var serveStatic = require('serve-static');

    // Define the configuration for all the tasks
    grunt.initConfig({

        // Project settings
        yeoman: appConfig,

        ngconstant: {
            // Options for all targets
            options: {
                space: '  ',
                wrap: '(function(){{\%= __ngModule %}})();',
                name: 'app.config',
            },
            // Environment targets
            development: {
                options: {
                    dest: '<%= yeoman.app %><%= yeoman.ngconstant.filePath %>'
                },
                constants: {
                    ENVIROMENT: {
                        projectName: currentProjectName,
                        name: 'development',
                        redirectUri: 'http://localhost:9000',
                        apiEndpoint: 'http://localhost:9001'
                    }
                }
            },
            production: {
                options: {
                    dest: '<%= yeoman.app %><%= yeoman.ngconstant.filePath %>'
                },
                constants: {
                    ENVIROMENT: {
                        projectName: currentProjectName,
                        name: 'development',
                        redirectUri: 'http://localhost:9000',
                        apiEndpoint: 'http://localhost:9001'                        
                    }
                }
            }
        },

        jsdoc: {
            dist: {
                src: ['<%= yeoman.app %>/{,*/}*.js', 'app/**/*.js', 'app/scripts/controllers/**/*.js', 'README.md', 'app/*.js', 'test/*.js'],
                options: {
                    destination: 'doc',
                    template: "node_modules/ink-docstrap/template",
                    configure: "node_modules/ink-docstrap/template/jsdoc.conf.json"
                }
            }
        },

        // Watches files for changes and runs tasks based on the changed files
        watch: {
            less: {
                files: "less/**/*.less",
                tasks: ['less:dist']
            },
            bower: {
                files: ['bower.json'],
                //tasks: ['wiredep']
            },
            js: {
                files: ['<%= yeoman.app %>/scripts/{,*/}*.js'],
                tasks: ['newer:jshint:all'],
                options: {
                    livereload: '<%= connect.options.livereload %>'
                }
            },
            jsTest: {
                files: ['test/spec/{,*/}*.js'],
                tasks: ['newer:jshint:test', 'karma']
            },
            styles: {
                files: ['<%= yeoman.app %>/styles/{,*/}*.css'],
                tasks: ['newer:copy:styles', 'autoprefixer']
            },
            gruntfile: {
                files: ['Gruntfile.js']
            },
            livereload: {
                options: {
                    livereload: '<%= connect.options.livereload %>'
                },
                files: [
                  '<%= yeoman.app %>/{,*/}*.html',
                  '.tmp/styles/{,*/}*.css',
                  '<%= yeoman.app %>/images/{,*/}*.{png,jpg,jpeg,gif,webp,svg}',
                  '<%= yeoman.app %>/resources/{,*/}*.json'
                ]
            }
        },

        // The actual grunt server settings
        connect: {
            options: {
                port: 9000,
                encoding: 'iso-8859-1',
                // Change this to '0.0.0.0' to access the server from outside.
                hostname: 'localhost',
                livereload: 35729,
                middleware: liverelioadMiddleware
            },
            livereload: {
                options: {
                    open: true,
                    encoding: 'iso-8859-1',
                    base: [
                      '.tmp',
                      'rewrite|/bower_components|./bower_components',
                      'rewrite|/app/styles|./app/styles', // for sourcemaps
                      '<%= yeoman.app %>'
                    ]
                }
            }
        },

        // Make sure code styles are up to par and there are no obvious mistakes
        jshint: {
            options: {
                jshintrc: '.jshintrc',
                reporter: require('jshint-stylish')
            },
            all: {
                src: [
                  'Gruntfile.js',
                  '<%= yeoman.app %>/scripts/{,*/}*.js'
                ]
            },
            test: {
                options: {
                    jshintrc: 'test/.jshintrc'
                },
                src: ['test/spec/{,*/}*.js']
            }
        },

        // Empties folders to start fresh
        clean: {
            dist: {
                files: [{
                    dot: true,
                    src: [
                      '.tmp',
                      '<%= yeoman.dist %>/{,*/}*',
                      '!<%= yeoman.dist %>/.git*'
                    ]
                }]
            },
            server: '.tmp'
        },

        // Add vendor prefixed styles
        autoprefixer: {
            options: {
                browsers: ['last 1 version']
            },
            dist: {
                files: [{
                    expand: true,
                    cwd: '.tmp/styles/',
                    src: '{,*/}*.css',
                    dest: '.tmp/styles/'
                }]
            }
        },

        imagemin: {
            dist: {
                files: [
                  {
                      expand: true,
                      cwd: '<%= yeoman.app %>/images',
                      src: '{,*/}*.{png,jpg,jpeg,gif}',
                      dest: '<%= yeoman.dist %>/images'
                  }, {
                      expand: true,
                      cwd: '<%= yeoman.app %>/template/img',
                      src: '{,*/}*.{png,jpg,jpeg,gif}',
                      dest: '<%= yeoman.dist %>/template/img'
                  }
                ]
            }
        },

        htmlmin: {
            dist: {
                options: {
                    removeComments: true,
                    collapseWhitespace: true,
                    conservativeCollapse: true,
                    collapseBooleanAttributes: true,
                    removeCommentsFromCDATA: true,
                    removeOptionalTags: true
                },
                files: [{
                    expand: true,
                    cwd: '<%= yeoman.dist %>',
                    src: '**/*.html',
                    dest: '<%= yeoman.dist %>'
                }]
            }
        },

        // ngAnnotate tries to make the code safe for minification automatically by
        // using the Angular long form for dependency injection. It doesn't work on
        // things like resolve or inject so those have to be done manually.
        ngAnnotate: {
            dist: {
                files: [{
                    expand: true,
                    cwd: '<%= yeoman.dist %>/scripts',
                    src: 'scripts.js',
                    dest: '<%= yeoman.dist %>/scripts',
                }]
            }
        },

        // Run some tasks in parallel to speed up the build process
        concurrent: {
            server: [
              'copy:styles'
            ],
            production: [
              'ngconstant:production'
            ],
            dist: [
              //'svgmin',
              //'cssmin',
              //'imagemin:dist',
              'htmlmin',
              'babel:dist'
            ]
        },

        // Copies remaining files to places other tasks can use
        copy: {
            dist: {
                files: [
                  {
                      expand: true,
                      dot: true,
                      cwd: '<%= yeoman.app %>',
                      dest: '<%= yeoman.dist %>',
                      src: [
                        '**/*.html', '**/*.json', '**/*.config',
                        //fav ico
                        '*.ico',
                        //apple touch icons
                        '*.png',
                        '*.gif',
                        //app images
                        'images/**/*.png', 'images/**/*.jpg', 'images/**/*.gif'
                      ]
                  },
                  {
                      flatten: true,
                      expand: true,
                      cwd: 'bower_components',
                      dest: '<%= yeoman.dist %>/fonts',
                      src: [
                        '**/fonts/*.+(eot|svg|ttf|woff|woff2)'
                      ]
                  },
                  {
                      expand: true,
                      cwd: 'bower_components',
                      dest: '<%= yeoman.dist %>/bower_components',
                      src: []
                  },
                  {
                      flatten: true,
                      expand: true,
                      cwd: 'bower_components',
                      dest: '<%= yeoman.dist %>/images',
                      src: []
                  }
                ]
            },
            styles: {
                expand: true,
                cwd: '<%= yeoman.app %>/styles',
                dest: '.tmp/styles/',
                src: '{,*/}*.css'
            }
        },

        babel: {
            options: {
                sourceMap: true,
                presets: ['@babel/preset-env']
            },
            dist: {
                files: [{
                    expand: true,
                    src: 'scripts.*.js',
                    dest: '<%= yeoman.dist %>/scripts',
                    cwd: '<%= yeoman.dist %>/scripts'
                }]
            }
        },

        uglify: {
            dist: {
                files: [{
                    expand: true,
                    src: 'scripts.*.js',
                    dest: '<%= yeoman.dist %>/scripts',
                    cwd: '<%= yeoman.dist %>/scripts'
                }]
            },
            options: {
                mangle: false
            },
        },

        // Reads HTML for usemin blocks to enable smart builds that automatically
        // concat, minify and revision files. Creates configurations in memory so
        // additional tasks can operate on them
        useminPrepare: {
            html: [
              '<%= yeoman.app %>/index.html'
            ],
            options: {
                dest: '<%= yeoman.dist %>',
                flow: {
                    html: {
                        steps: { js: ['concat'], css: ['concat'] }, post: {}
                    }
                }
            }
        },

        // Performs rewrites based on filerev and the useminPrepare configuration
        usemin: {
            html: [
              '<%= yeoman.dist %>/index.html'
            ],
            options: {
                blockReplacements: {
                    base: function (block) {
                        return ['<base href="/">'].join('');
                    }
                }
            }
        },

        // Renames files for browser caching purposes
        filerev: {
            options: {
                encoding: 'utf8',
                algorithm: 'md5',
                length: 8
            },
            source: {
                files: [{
                    src: [
                      '<%= yeoman.dist %>/index.html',

                      '<%= yeoman.dist %>/scripts/**/*.html',

                      '<%= yeoman.dist %>/scripts/scripts.js',
                      '<%= yeoman.dist %>/scripts/vendor.js',

                      '<%= yeoman.dist %>/styles/vendor.css',
                      '<%= yeoman.dist %>/styles/template.css',
                      '<%= yeoman.dist %>/styles/main.css'
                    ]
                }]
            }
        },

        userev: {
            options: {
                hash: /(\.[a-f0-9]{8})\.[a-z]+$/,
            },
            index: {
                src: [
                  '<%= yeoman.dist %>/index.*.html',
                ],
                options: {
                    patterns: {
                        'Replace js script': /scripts\/scripts.js/g,
                        'Replace js vendor': /scripts\/vendor.js/g,

                        'Replace css vendor': /styles\/vendor.css/g,
                        'Replace css template': /styles\/template.css/g,
                        'Replace css main': /styles\/main.css/g
                    }
                },
            },
            anyhtml: {
                src: [
                  '<%= yeoman.dist %>/scripts/**/*.html',
                ],
                options: {
                    patterns: {
                        'Replace html in includes': /([^''""]*\.(html))/g,
                    },
                },
            },

            scripts: {
                src: [
                  '<%= yeoman.dist %>/scripts/scripts.*.js',
                ],
                options: {
                    patterns: {
                        'Replace templates script': /(scripts\/[^''""]*\.(html))/g,
                    },
                },
            },
            webconfig: {
                src: [
                  '<%= yeoman.dist %>/web.config'
                ],
                options: {
                    patterns: {
                        'Replace webconfig index.html': /(index.html)/g
                    },
                },
            },
        },

        less: {
            dist: {
                options: {
                    compress: true,
                    yuicompress: true,
                    optimization: 2
                },
                files: {
                    "<%= yeoman.app %>/styles/bootstrap.css": "less/bootstrap.less",
                    "<%= yeoman.app %>/styles/app.css": "less/app.less", // destination file and source file
                    "<%= yeoman.app %>/styles/materialicons.css": "less/app/material/icons.less" // destination file and source file
                }
            }
        }
    });

    grunt.registerTask('serve', 'Compile then start a connect web server', function (target) {
        grunt.task.run(['development']);
    });

    grunt.registerTask('development', [
      'clean:server',
      'ngconstant:development', //Set Config para a API Local
      'less:dist',
      'concurrent:server',
      'autoprefixer',
      'connect:livereload',
      'watch'
    ]);

    grunt.registerTask('production', function () {
        grunt.task.run([
          'concurrent:production',
          'publish',
          'concurrent:dist',
          'uglify:dist'
        ]);
    });

    grunt.registerTask('publish', [
      'clean:dist',
      'copy:dist',
      'less:dist',
      'useminPrepare',
      'concat',
      'ngAnnotate',
      'usemin',
      'filerev',
      'userev'
    ]);
};
