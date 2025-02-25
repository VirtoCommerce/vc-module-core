angular.module('virtoCommerce.coreModule.common')
    .factory('virtoCommerce.coreModule.common.dynamicExpressionService', function () {
        var retVal = {
            expressionTreeTemplateUrl: '',
            expressions: [],
            registerExpression: function (expression) {
                if (!expression.templateURL) {
                    expression.templateURL = 'expression-' + expression.id + '.html';
                }

                this.expressions[expression.id] = expression;
            }
        };
        return retVal;
    })
    .directive('vaDynamicExpressionTree', function () {
        return {
            restrict: 'E',
            //scope: {
            //    source: '='
            //},
            link: function ($scope, $element, $attrs) {
                $scope.toggle = function ($event) {
                    var elem = $event.target;
                    if (elem.tagName === 'I') {
                        elem = elem.parentElement;
                    }
                    var childUlElement = $(elem).find("ul");
                    if (childUlElement.length > 0) {
                        var iconElement = $(elem).find("i");
                        if (iconElement.hasClass("fa-caret-down")) {
                            iconElement.removeClass("fa-caret-down");
                            iconElement.addClass("fa-caret-right");
                        }
                        else {
                            iconElement.removeClass("fa-caret-right");
                            iconElement.addClass("fa-caret-down");
                        }
                        childUlElement.toggle();
                        $event.stopPropagation();
                    }
                };
                $scope.addChild = function (chosenMenuElement, parentBlock) {
                    if (!parentBlock.children) {
                        parentBlock.children = [];
                    }
                    parentBlock.children.push(angular.copy(chosenMenuElement));
                };
                $scope.deleteChild = function (child, parentList) {
                    parentList.splice(parentList.indexOf(child), 1);
                }

                $scope.$watch($attrs.source, function (newVal) {
                    $scope.source = newVal;
                });

                $scope.templateUrl = 'Modules/$(VirtoCommerce.Core)/Scripts/dynamicConditions/expression-tree.tpl.html';
                $scope.$watch($attrs.templateUrl, function (value) {
                    if (value) {
                        $scope.templateUrl = value;
                    }
                });
            },
            template: '<div ng-include="templateUrl"></div>'
        };
    });
