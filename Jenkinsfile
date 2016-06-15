node
{
	//checkout scm
	checkout([$class: 'GitSCM', branches: [[name: "*/master"]], userRemoteConfigs: [[refspec: '+refs/pull/*:refs/remotes/origin/pr/*']]])
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
