node
{
	//checkout scm
	checkout([
		$class: 'GitSCM', 
		branches: [[name: "*/${env.BRANCH_NAME}"]]
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
