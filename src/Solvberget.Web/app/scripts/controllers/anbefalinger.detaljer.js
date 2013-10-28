'use strict';

angular.module('Solvberget.WebApp')
    .controller('AnbefalingerDetaljerCtrl', function ($scope, $rootScope, $routeParams, lists) {

        $scope.list = lists.get({id : $routeParams.id}, function(){

            $rootScope.breadcrumb.push($scope.list.Name, 'AnbefalingerDetaljerCtrl', {id: $scope.list.Id});
        });

        $rootScope.breadcrumb.clear();
        $rootScope.breadcrumb.push('Anbefalinger', 'AnbefalingerCtrl');

        $scope.pathFor = function(item){
            var title = encodeURIComponent(item.Title.replace(' ','-').toLowerCase());
            return $rootScope.path(item.Type + 'Ctrl', {id: item.Id, title : title});
        };
    });
