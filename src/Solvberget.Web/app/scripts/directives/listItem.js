angular.module('Solvberget.WebApp')
    .directive('listItem', function() {
        return {
            scope : {
                title:"=listItem",
                imageUrl:"=imageUrl",
                url:"=url",
                subtext:"=subtext",
                showChevron:"=showChevron",
                showDelete:"=showDelete",
                showFavorite:"=showFavorite",
                isFavorite:"=isFavorite",
                type:"=documentType",
                gutterTextPrefix:"=gutterTextPrefix",
                gutterText:"=gutterText",
                documentId:"=documentId"
            },
            controller: function($scope, favorites, renewals) {

                $scope.toggleFavorite = function() {

                    if ($scope.isFavorite) favorites.remove({ documentId: $scope.documentId });
                    else favorites.add({ documentId: $scope.documentId });

                    $scope.isFavorite = !$scope.isFavorite; // todo: handle failure
                };

                $scope.renew = function() {
                    renewals.add({ documentId: $scope.documentId });
                };
            },
            replace:true,
            templateUrl: 'views/listItem.html'
        };
    });

