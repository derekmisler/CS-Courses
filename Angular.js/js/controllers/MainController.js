/*global app */
app.controller('MainController', ['$scope', function($scope) {
	$scope.title = 'Important Items';
	$scope.promo = 'A list of things';
	$scope.products =
	[
		{
			name: 'The Book of Trees',
			price: 19,
			pubdate: new Date('2014', '03', '08'),
			cover: 'img/the-book-of-trees.jpg',
			likes: 0,
			dislikes: 0
		},
		{
			name: 'Program or be Programmed',
			price: 8,
			pubdate: new Date('2013', '08', '01'),
			cover: 'img/program-or-be-programmed.jpg',
			likes: 0,
			dislikes: 0
		},
		{
			name: 'The Pragmatic Programmer',
			price: 32.95,
			pubdate: new Date('1999', '10', '03'),
			cover: 'img/the-book-of-trees.jpg',
			likes: 0,
			dislikes: 0
		},
		{
			name: 'Clean Code',
			price: 40.45,
			pubdate: new Date('2008', '08', '11'), 
			cover: 'img/program-or-be-programmed.jpg',
			likes: 0,
			dislikes: 0
		}
	];
	$scope.plusOne = function(index) {
		$scope.products[index].likes += 1;
	};
	$scope.minusOne = function(index) {
		$scope.products[index].dislikes += 1;
	};
}]);