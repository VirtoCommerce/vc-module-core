node
{
	//checkout scm
	checkout([$class: 'GitSCM', branches: [[name: "refs/remotes/origin/master"]], userRemoteConfigs: [[refspec: '+refs/heads/*:refs/remotes/origin/*']]])
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
