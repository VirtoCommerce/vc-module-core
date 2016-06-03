node {
	stage 'Checkout'
		checkout scm

	stage 'Build'
		bat 'nuget restore VirtoCommerce.CoreModule.sln'
		bat "\"${tool 'MSBuild'}\" VirtoCommerce.CoreModule.sln /p:Configuration=Debug /p:Platform=\"Any CPU\""

}
