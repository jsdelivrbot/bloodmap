(function () {

    'use strict';

    angular.module('jadeSampleApp')
    .controller('myAccountsContactController', myAccountsContactCtrlDefinition);

    myAccountsContactCtrlDefinition.$inject = ['$scope'];

    function myAccountsContactCtrlDefinition($scope) {


        var vm = this;
       
        $scope.data.availableOptions = [
  { id: 1, tag: 'DR' },
  { id: 2, tag: 'FR' },
  { id: 3, tag: 'MIS' },
  { id: 4, tag: 'MISS' },
  { id: 5, tag: 'MR' },
  { id: 6, tag: 'MRS'},
  { id: 7, tag: 'MS' },
  { id: 8, tag: 'MS' },
  { id: 9, tag: 'Prof'},
  
        ];

        var
     nameList = ['Pierre', 'Pol', 'Jacques', 'Robert', 'Elisa'],
     familyName = ['Dupont', 'Germain', 'Delcourt', 'bjip', 'Menez'];

        function createRandomItem() {
            var
                firstName = nameList[Math.floor(Math.random() * 4)],
                lastName = familyName[Math.floor(Math.random() * 4)],
                age = Math.floor(Math.random() * 100),
                email = firstName + lastName + '@whatever.com',
                balance = Math.random() * 3000;

            return {
                firstName: firstName,
                lastName: lastName,
                age: age,
                email: email,
                balance: balance
            };
        }

        vm.itemsByPage = 5;
        vm.selectedJDE = -1;
        vm.rowCollection = [];
        vm.isJDESelected = false;
        for (var j = 0; j < 200; j++) {
            vm.rowCollection.push(createRandomItem());
        }

      
    }
}
)();