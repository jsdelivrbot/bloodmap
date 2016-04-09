(function () {

    'use strict';

    angular.module('jadeSampleApp')
    .controller('myAccountsModalController', myAccountsModalCtrlDefinition);

    myAccountsModalCtrlDefinition.$inject = ['$scope', '$element', 'JDEId', 'title', 'close'];

    function myAccountsModalCtrlDefinition($scope, $element, JDEId, title, close) {


        $scope.myAccountTabsList = [
            { tabName: "Details", templateName: "partials/subpartials/myAccountDetails.html" },
            {tabName: "Dashboard", templateName: "partials/subpartials/myAccountDashboard.html"},
            { tabName: "Contact", templateName: "partials/subpartials/myAccountContact.html" },
            { tabName: "Notes", templateName: "partials/subpartials/myAccountNotes.html" },
            { tabName: "Lead Notes", templateName: "partials/subpartials/myAccountLeadNotes.html" },
            { tabName: "Campaign", templateName: "partials/subpartials/myAccountCampaign.html" },
            { tabName: "Campaign Activities Completed", templateName: "partials/subpartials/myAccountCampaignComp.html" },
            { tabName: "Call Detail", templateName: "partials/subpartials/myAccountCallDetail.html" },
            { tabName: "Email Tracker", templateName: "partials/subpartials/myAccountEmailTracker.html" },
        ];
        $scope.JDEId = JDEId;
        $scope.title = title;
        $scope.isCreateContact = false;
        $scope.data = {
            repeatSelect: null,
            availableOptions: [
              { id: '1', name: 'Option A' },
              { id: '2', name: 'Option B' },
              { id: '3', name: 'Option C' }
            ],
        };
        $scope.close = function () {
            close({
                JDEId: $scope.JDEId
            }, 500); // close, but give 500ms for bootstrap to animate
        };

        $scope.cancel = function () {

            //  Manually hide the modal.
            $element.modal('hide');

            //  Now call close, returning control to the caller.
            close({
                JDEId: $scope.JDEId
            }, 500); // close, but give 500ms for bootstrap to animate
        };

        $scope.showCreateContactPanel = function () {
            $scope.isCreateContact = true;
        }
    }
}
)();