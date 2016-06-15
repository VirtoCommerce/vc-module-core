#!groovy

node
{
	//checkout scm
	checkout([
		$class: 'GitSCM', 
		branches: [[name: "refs/heads/${env.BRANCH_NAME}"]], 
		userRemoteConfigs: [[
			credentialsId: 'sasha-jenkins', 
			url: "git@github.com:VirtoCommerce/vc-module-core.git"
		]],
		extensions: [[
			$class: 'PathRestriction', 
			excludedRegions: 'CommonAssemblyInfo\\.cs', 
			includedRegions: ''
		],
		[
			$class: 'MessageExclusion', 
			excludedMessage: '.*\\[ignore-this-commit\\].*'
		]]
	])
	
	/* 
	checkout([
		$class: 'GitSCM', 
		branches: [[name: "refs/heads/${env.BRANCH_NAME}"]], 
		userRemoteConfigs: [[
			credentialsId: 'sasha-jenkins', 
			url: "git@github.com:VirtoCommerce/vc-module-core.git",
			refspec: 'master'
		]],
		extensions: [[
			$class: 'PathRestriction', 
			excludedRegions: 'CommonAssemblyInfo\\.cs', 
			includedRegions: ''
		],
		[
			$class: 'MessageExclusion', 
			excludedMessage: '.*\\[ignore-this-commit\\].*'
		]]
	])
	*/
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
