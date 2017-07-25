//angular authentication module for 
(function () {
    var app = angular.module("authApp", []);
    var authController = function ($scope, $http, $window) {
        $scope.register = {
            "Email": "",
            "Password": "",
            "ConfirmedPassword": ""
        };
        $scope.login = {
            "Email": "",
            "Password": ""
        };
        $scope.data;
        $scope.user;

        $scope.RequestRegister = Register;

        function Register() {
            $http.post("/api/Account/Register", $scope.register).then(function successCallback(response){
                //This callback will be called asynchonously when the result is available
                $scope.result = "Registration was successful";
            },
            function errorCallback(err) {
                //This callback will be called asynchonously when the result is available
                $scope.result = err.status + err.err.statustext;
            });
        };

        $scope.RequestLogin = function () {
            var data = "grant_type=password&username=" + $scope.login.Email + "&password=" + $scope.login.Password;
            alert(data);
            $http.post("/Token", data
                ).then(
                function (response) {
                    //This callback will be called asynchonously when the result is available
                    $scope.user = response.data.userName;
                    $window.sessionStorage.setItem('tokenKey', response.data.access_token);
                },
                function (response) {
                    //This callback will be called asynchonously when the result is available
                    alert("Fail!");
                }

                );
        };

        $scope.RequestData = function () {
            var token = $window.sessionStorage.getItem('tokenKey');
            var headers = {};
            if (token) {
                headers.Authorization = 'Bearer ' + token;
            };
            var config = { headers: headers };
            $http.get('api/Values', config).then(
                function (response) {
                    $scope.data = response.data;
                },
                function()
                {
                    alert("Fail!");
                }
                );
        };
    };

    app.controller("authController", ["$scope", "$http", "$window", authController]);
}());