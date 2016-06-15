node
{
	//checkout scm
	checkout([
		$class: 'GitSCM', 
		branches: [[name: "${env.BRANCH_NAME}"]], 
		userRemoteConfigs: [[
			credentialsId: 'sasha-jenkins', url: "git@github.com:VirtoCommerce/vc-module-core.git"
		]]
	])
	/*
	: [
		$class: 'GitSCM', 
		extensions: [[
			$class: 'PathRestriction', 
			excludedRegions: 'CommonAssemblyInfo\\.cs', 
			includedRegions: ''
		]]
	]
	
	userRemoteConfigs: [[refspec: '+refs/pull/*:refs/remotes/origin/pr/*']]*
	*/
	/*
	virtoModule {
		name = 'core'
		solution = 'VirtoCommerce.CoreModule.sln'
	} 
	*/
}
