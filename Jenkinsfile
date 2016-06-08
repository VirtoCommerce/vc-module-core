node {
	env.WORKSPACE = pwd()
	echo "${env.WORKSPACE}"
	echo "${env.VC_RES}"
	stage 'Checkout'
		checkout([$class: 'GitSCM', extensions: [[$class: 'PathRestriction', excludedRegions: 'CommonAssemblyInfo\\.cs', includedRegions: '']]])
		bat "powershell.exe -File \"${env.VC_RES}\\script\\version3.ps1\" -solutiondir \"${env.WORKSPACE}\""
		git commit
		git push
		
	stage 'Build'
		bat "Nuget restore VirtoCommerce.CoreModule.sln"
		bat "\"${tool 'MSBuild 12.0'}\" VirtoCommerce.CoreModule.sln /p:Configuration=Debug /p:Platform=\"Any CPU\""
		
	if (env.BRANCH_NAME == 'master') {
				
		stage 'Nuget Package'
	   		bat 'Nuget\\build.bat'
	   		
	   	
	} 
	
	step([$class: 'GitHubCommitStatusSetter', statusResultSource: [$class: 'ConditionalStatusResultSource', results: []]])
}
