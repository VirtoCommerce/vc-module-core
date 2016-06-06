node {
	stage 'Checkout'
		checkout scm

	stage 'Build'
		bat 'c:\\Builds\\Jenkins\\Utils\\Nuget\\3.3.0\\nuget restore VirtoCommerce.CoreModule.sln'
		bat "\"${tool 'MSBuild 12.0'}\" VirtoCommerce.CoreModule.sln /p:Configuration=Debug /p:Platform=\"Any CPU\""
		
	if (env.BRANCH_NAME == 'master') {
		stage 'Nuget Package'
			dir('nuget') {
		   		bat 'build.bat'
			}
			
	}
}
