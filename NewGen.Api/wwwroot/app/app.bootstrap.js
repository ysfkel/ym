
/**
 * @ngdoc 
 * @description this is the application entry             
 */
var app=require('./modules/app');

// require('./sockets')(app);
// require('./mock')(app);
// require('./services')(app)
// require('./utillity/utill')(app);
 require('./app.config')(app)
// require('./layout')(app);
// require('./product')(app);
// require('./storage/local-store')(app);

  angular.bootstrap(document.getElementById('js_ng_app_page'),['ngApp'])

