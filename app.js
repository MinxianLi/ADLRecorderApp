	var app = angular.module('app', ['ngResource','ngMockE2E',"ngMaterial", 'ngMdIcons','ngStorage']);


	app.controller("TaskCtrl", function($scope, $mdDialog, $mdDialog,$http,$rootScope) {
        $scope.todos =[];
	    $rootScope.editItem = {};
		var imagePath = 'https://material.angularjs.org/latest/img/list/60.jpeg?0';
		$scope.getTodos = function() {
			$http.get('/todos').success(function(data) {
				 angular.forEach(data, function(value, key){
				 	 var item = {
				title: value.title,
				description: value.description,
				due:  new Date(value.due),
				done: value.done
			};
                    $scope.todos.push(item);
				 });
			 
			});
		}
		 $scope.todo = {
         due: new Date()
         };
        $scope.taskdue = new Date($scope.todo.due);


		$scope.editIndex = 0;

		$scope.add = function() {
			var item = {
				title: $scope.tasktit,
				description: $scope.taskdes,
				due: $scope.taskdue,
				done: false
			};

			$scope.todos.push(item);  
			$http.post('/todos', item).then(function() {
				$scope.newtask =    {
					title:'',
					description: '',
					due: '',
					done: false
				};
				return $scope.getTodos();
			 
		}); 



		};

		$scope.removeItem = function(index) {
			$scope.todos.splice(index, 1);

		};

		$scope.editItem = function(index, event) {
			$scope.editIndex = index;
			$rootScope.editItem = $scope.todos[index];
			$scope.showAdvanced(event);
	        //$scope.updateLocal();
	    };
	    $scope.updateDone = function(index){

	    	$scope.todos[index].done = true;

	    	
	    }
	    $scope.updateNotDone = function(index){

	    	$scope.todos[index].done = false;

	    	
	    }
	    $scope.showAdvanced = function(ev) {

	    	$mdDialog.show({
	    		controller: DialogController,
	    		template:  '<md-dialog aria-label="Edit Task">'+
	    		' <div  layout-gt-sm="row">'+
                ' <md-input-container class="md-block" flex-gt-sm=""> '+
                '<label>Title</label>'+
                 '<input ng-model="editItem.title">'+
                 ' </md-input-container>'+
                ' <md-input-container class="md-block" flex-gt-sm="">'+
                '  <label>Description</label>'+
                ' <input ng-model="editItem.description" type="email">'+
                ' </md-input-container>'+
                '    </div>'+
                '<div  layout-gt-sm="row">'+
                ' <md-input-container class="md-block" flex-gt-sm="">'+
                '  <label>Due date</label>'+
                '  <md-datepicker ng-model="editItem.due"></md-datepicker>'+
                '</md-input-container>'+
                ' </div>'+
                '  <md-button class="md-raised md-primary" ng-click="Update()">Edit</md-button>'+
                '</md-dialog>'

	    		,
	    		targetEvent: ev,
	    	})
	    	.then(function() {
	    		console.log('todos:' + JSON.stringify($scope.todos));
	    		$scope.todos[$scope.editIndex].description =  $rootScope.editItem.description;
	    		$scope.todos[$scope.editIndex].title = $rootScope.editItem.title;
	    		$scope.todos[$scope.editIndex].due = $rootScope.editItem.due;
	    		 
	    	}, function() {
	                //$scope.alert = 'You cancelled the dialog.';
	            });
	    };

	    
	    $scope.updateLocal = function(items) {
	        //$localStorage.itemList = "[]";
	        $localStorage.itemList = JSON.stringify(items);
	    };
	});

	function DialogController($scope, $mdDialog,$rootScope) {
		$scope.editItem ={};
		$scope.editItem = $rootScope.editItem;
		$scope.hide = function() {
			$mdDialog.hide();
		};
		$scope.cancel = function() {
			$mdDialog.cancel();
		};
		$scope.Update = function(content,test,test2) {
			$rootScope.editItem = $scope.editItem;
			console.log("task:" + content);
			$mdDialog.hide(content);
		};
	}

	app.config(function($mdThemingProvider) {
		var customBlueMap = $mdThemingProvider.extendPalette('light-blue', {
			'contrastDefaultColor': 'light',
			'contrastDarkColors': ['50'],
			'50': 'ffffff'
		});
		$mdThemingProvider.definePalette('customBlue', customBlueMap);
		$mdThemingProvider.theme('default')
		.primaryPalette('customBlue', {
			'default': '500',
			'hue-1': '50'
		})
		.accentPalette('pink');
		$mdThemingProvider.theme('input', 'default')
		.primaryPalette('grey')
	});