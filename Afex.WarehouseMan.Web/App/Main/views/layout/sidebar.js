﻿(function () {
    var controllerId = 'app.views.layout.sidebar';
    angular.module('app').controller(controllerId, [
        '$rootScope', '$state', 'appSession',
        function ($rootScope, $state, appSession) {
            var vm = this;

            vm.languages = abp.localization.languages;
            vm.currentLanguage = abp.localization.currentLanguage;

            vm.menu = abp.nav.menus.MainMenu;
            vm.currentMenuName = $state.current.menu;

            $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
                vm.currentMenuName = toState.menu;
            });

            vm.getShownUserName = function () {
                if (!abp.multiTenancy.isEnabled) {
                    return appSession.user.userName;
                } else {
                    if (appSession.tenant) {
                        return appSession.tenant.tenancyName + '\\' + appSession.user.userName;
                    } else {
                        return '.\\' + appSession.user.userName;
                    }
                }
            };

            vm.getUserEmail = function () {
                return appSession.user.emailAddress;
            }

            abp.event.on('abp.notifications.received', function (userNotification) {
                abp.notifications.showUiNotifyForUserNotification(userNotification);
            });
        }
    ]);
})();