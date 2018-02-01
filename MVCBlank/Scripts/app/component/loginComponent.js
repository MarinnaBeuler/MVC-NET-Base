(function () {
    'use strict';

    angular.module(appName).component("loginForm", {
        bindings: {},
        templateUrl: "/Scripts/app/component/login.html",
        controller: function ($scope, authService) {
            var vm = this;
            vm.loginData = {};
            vm.login = _login;
            vm.logout = _logout;

            function _login() {
                authService.login(vm.loginData).then(function (res) {
                    console.log("login success response", res);
                }).catch(function (err) {
                    console.log("login error", err)
                });
            }
            function _logout() {
                authService.logout();
            }
        }
    })
})()