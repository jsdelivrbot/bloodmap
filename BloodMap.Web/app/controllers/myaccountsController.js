(function () {
    'use strict';

    angular.module('jadeSampleApp')
    .controller('myaccountsController', myAccountsControllerDef);
    myAccountsControllerDef.$inject = ['$scope', 'ModalService'];
    function myAccountsControllerDef($scope, ModalService) {

        var vm = this;
       
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

        //retrieve the JDE of selected row
        vm.getSelectedJDE = function (rowId) {
            vm.selectedJDE = rowId;
            vm.isJDESelected = true;
            console.log("Selected Item : " + rowId);
        };
        
        //modal
        vm.openAccountDetailsModal = function () {

            ModalService.showModal(
                {
                    templateUrl: "partials/myAccountsModal.html",
                    controller: "myAccountsModalController",
                    inputs: {
                        JDEId: vm.selectedJDE,
                        title:"My Account Details"
                    }
                }).then(function (modal) {
                    modal.element.modal();

                    modal.close.then(function (result) {

                    });
                });
        }
    }
})();