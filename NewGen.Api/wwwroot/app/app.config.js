

/**
 * @name app.config
 * @requires $stateProvider, $urlRouterProvider, $httpProvider
 * @description configues the applications routes            
 */
//var productCollection = require('./models/productCollection');
module.exports = function (app) {

    app.config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider', '$httpProvider'];

    function config($stateProvider, $urlRouterProvider, $httpProvider) {
        //imports style sheets
       // require('./layout/nav.css');
       // require('./product/style/product.scss');
       // require('./shared/style/style.scss');

        $stateProvider
            .state('base', {
                abstract: true,
               template: require('./layout/templates/layout.html')
               // , controller: 'LayoutController as $ctrl'
            })
            .state('base.blog', {
                url: "/blog-list",
                //   template:'<h1>HELLO ANGULAR</h1>' //require('./blog/templates/list.html')
                views: {
                    'view-content': {
                        template: require('./blog/templates/list.html')
                       //,controller: 'blogListController as $ctr'
                       
                    }
                }
            })


     //   $urlRouterProvider.otherwise('/blog-list2');

    }
}


