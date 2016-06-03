node {
	stage 'Checkout'
		checkout scm

	stage 'Build'
		bat 'c:\Builds\Jenkins\Utils\Nuget\3.3.0\nuget restore VirtoCommerce.CoreModule.sln'
		bat "\"${tool 'MSBuild'}\" VirtoCommerce.CoreModule.sln /p:Configuration=Debug /p:Platform=\"Any CPU\""

}
