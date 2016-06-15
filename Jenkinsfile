node
{
	//checkout scm
	checkout([$class: 'GitSCM', userRemoteConfigs: [[refspec: '+refs/heads/*:refs/remotes/origin/*']]])
	/*
	: [
		$class: 'GitSCM', 
		extensions: [[
			$class: 'PathRestriction', 
			excludedRegions: 'CommonAssemblyInfo\\.cs', 
			includedRegions: ''
		]]
	]
	*/
	/*
	virtoModule {
		name = 'core'
		solution = 'VirtoCommerce.CoreModule.sln'
	} 
	*/
}
