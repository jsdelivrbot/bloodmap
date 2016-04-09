(
function () {
    'use strict';

    angular.module('BloodMap')
    .constant('SYSTEM_COMMON_CONFIG',
    {
        apiBaseUrl: "http://localhost:46556",
        commonApi:"/api",
        apiPrefix:{
            login:"/login"
        },
        Token_Spec:[
            "AccessToken"
        ],
        GrantType: "password",
        GrantType_RenewToken: "refresh_token",
        Refresh_Token: "refresh_token",
        App_Idle_Timeout: 3600
    }
    );
}
)();