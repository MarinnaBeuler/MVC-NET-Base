(function () {
    angular.module(appName).factory("authService", AuthService);
    AuthService.$inject = ["$http", "$q", "localStorageService"];
    function AuthService($http, $q, localStorageService) {
        var authServiceObj = {
            login: _login,
            logout: _logout
        }
        return authServiceObj;

        function _login(loginData) {
            var encoded = window.btoa(loginData.userName + ":" + loginData.password);
            var deffered = $q.defer();

            $http({
                method: "POST",
                dataType: "json",
                url: "/api/auths/login",
                headers: {
                    "Authorization": "Basic " + encoded,
                    "Content-Type": "application/x-www-form-urlencoded",
                    "Access-Control-Allow-Origin": "*"
                }
            }).then(function (res) {
                localStorageService.set("authorizationData", {
                    token: res.headers("Token"),
                    tokeExpires: res.headers("TokenExpires")
                });
                deffered.resolve(res);
            }).catch(function (err) {
                deffered.reject(err);
                });

            return deffered.promise;
        }
        function _logout() {
            return localStorageService.remove("authorizationData");
        }
    }
})()